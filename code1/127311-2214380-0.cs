    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace Juliet
    {
        class Employee
        {
            public event Action<Employee> OnSalaryChanged;
    
            public string Name { get; set; }
            public string Title { get; set; }
    
            private decimal _salary;
            public decimal Salary
            {
                get { return _salary; }
                set
                {
                    _salary = value;
                    if (OnSalaryChanged != null)
                        OnSalaryChanged(this);
                }
            }
    
            public Employee(string name, string title, decimal salary)
            {
                this.Name = name;
                this.Title = title;
                this.Salary = salary;
            }
        }
    
        class TaxMan
        {
            public void Update(Employee e)
            {
                Console.WriteLine("Send {0} a new tax bill!", e.Name);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var fred = new Employee("Fred", "Crane operator", 30000.0M);
                var taxMan = new TaxMan();
                fred.OnSalaryChanged += taxMan.Update;
    
                fred.Salary = 40000.0M;
            }
        }
    }
