using System;
using System.Reflection.Metadata;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Employee(int id, string name, String department, decimal salary)
    {
        Id = id;
        Name = name;
        Department = department;
        Salary = salary;

    }

    public override string ToString()
    {
        return $"ID:{Id},Name:{Name},Department:{Department},Salary:{Salary:C}";
    }
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            Console.WriteLine("Employee added successfully");
        }
        public void EditEmployee(int id, string newName, string newDepartment, decimal newSalary)
        {

            Employee employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                employee.Name = newName;
                employee.Department = newDepartment;
                employee.Salary = newSalary;
                Console.WriteLine("Employee details updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }

        }
        public void DeleteEmployee(int id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void SearchEmployee(int id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void DisplayAllEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }






    }


    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Edit Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Search Employee");
                Console.WriteLine("5. Display All Employees");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Department: ");
                        string department = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());
                        manager.AddEmployee(new Employee(id, name, department, salary));
                        break;
                    case "2":
                        Console.Write("Enter Employee ID to Edit: ");
                        int editId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter New Department: ");
                        string newDepartment = Console.ReadLine();
                        Console.Write("Enter New Salary: ");
                        decimal newSalary = decimal.Parse(Console.ReadLine());
                        manager.EditEmployee(editId, newName, newDepartment, newSalary);
                        break;
                    case "3":
                        Console.Write("Enter Employee ID to Delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        manager.DeleteEmployee(deleteId);
                        break;
                    case "4":
                        Console.Write("Enter Employee ID to Search: ");
                        int searchId = int.Parse(Console.ReadLine());
                        manager.SearchEmployee(searchId);
                        break;
                    case "5":
                        manager.DisplayAllEmployees();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}