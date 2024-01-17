using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        Employee employee1 = null;
        bool flag = true;

        while (flag)
        {
            Console.WriteLine("Enter choice 1: Add Employees  2: Display All Employees 3. Display Total no of employees 4. Exit ");
            byte c = byte.Parse(Console.ReadLine());

            switch (c)
            {
                case 1:
                    Console.WriteLine("Which employee do you want to add? 1: OnPayroll Employee 2: OnContract Employee");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        employee1 = new OnPayrollEmployee();
                        employees.Add((OnPayrollEmployee)employee1);
                    }
                    else if (choice == 2)
                    {
                        employee1 = new OnContractEmployee();
                        employees.Add((OnContractEmployee)employee1);
                    }
                    break;
                case 2:
                    Console.WriteLine("All Employees:");
                    foreach (var employee in employees)
                    {
                        employee.DisplayDetails();
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("Total no of employees: ");
                    Console.WriteLine(employees.Count());
                    Console.WriteLine();
                    break;
                case 4:
                    flag = false;
                    break;
                default:
                    flag = false;
                    break;
            }
        }
    }
}

class Employee
{
    public int Id { get; set; }
    public string fullname { get; set; }
    public string Name { get; set; }
    public string Manager { get; set; }

    public Employee()
    {
        Console.WriteLine("Enter details for employee");
        Console.WriteLine("Enter Id :");
        Id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Name :");
        Name = Console.ReadLine();
        Console.WriteLine("Enter manager's name");
        Manager = Console.ReadLine();
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"id : {this.Id}");
        Console.WriteLine($"Name : {this.Name}");
        Console.WriteLine($"Manager : {this.Manager}");

    }
}


class OnContractEmployee : Employee
{
    public DateOnly ContractDate { get; set; }

    public float Duration { get; set; }

    public double Charges { get; set; }

    public OnContractEmployee() : base()
    {
        Console.WriteLine("Enter ContractDate in DD/MM/YYYY:");
        this.ContractDate = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("Enter Duration");
        this.Duration = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter Charges");
        this.Charges = double.Parse(Console.ReadLine());
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Contract Date : {this.ContractDate}");
        Console.WriteLine($"Duration : {this.Duration}");
        Console.WriteLine($"Charges : {this.Charges}");
    }

}

class OnPayrollEmployee : Employee
{
    public DateOnly JoiningDate { get; set; }
    public float ExpInYears { get; set; }
    public double BasicSalary { get; set; }
    private double DA { get; set; }
    private double HRA { get; set; }
    private double PF { get; set; }
    private double NetSalary { get; set; }

    public void CalculateNetSalary()
    {
        if (this.ExpInYears > 10)
        {
            this.DA = this.BasicSalary * (0.1);
            this.HRA = this.BasicSalary * (0.085);
            this.PF = 6200;
            this.NetSalary = this.DA + this.HRA - this.PF + this.BasicSalary;
        }
        else if (this.ExpInYears > 7)
        {
            this.DA = this.BasicSalary * (0.07);
            this.HRA = this.BasicSalary * (0.065);
            this.PF = 4100;
            this.NetSalary = this.DA + this.HRA - this.PF + this.BasicSalary;
        }
        else if (this.ExpInYears > 5)
        {
            this.DA = this.BasicSalary * (0.041);
            this.HRA = this.BasicSalary * (0.038);
            this.PF = 1800;
            this.NetSalary = this.DA + this.HRA - this.PF + this.BasicSalary;
        }
        else
        {
            this.DA = this.BasicSalary * (0.019);
            this.HRA = this.BasicSalary * (0.020);
            this.PF = 1200;
            this.NetSalary = this.DA + this.HRA - this.PF + this.BasicSalary;
        }
    }

    public OnPayrollEmployee() : base()
    {
        try
        {
            Console.WriteLine("Enter Joining Date in DD/MM/YYYY :");
            this.JoiningDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Experience in Years :");
            this.ExpInYears = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Basic Salary :");
            this.BasicSalary = double.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        CalculateNetSalary();
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Joining Date : {this.JoiningDate}");
        Console.WriteLine($"Experiance in Years : {this.ExpInYears}");
        Console.WriteLine($"Basic Salary : {this.BasicSalary}");
        Console.WriteLine($"DA : {this.DA}");
        Console.WriteLine($"HRA : {this.HRA}");
        Console.WriteLine($"PF : {this.PF}");
        Console.WriteLine($"Net  : {this.NetSalary}");
    }
}
