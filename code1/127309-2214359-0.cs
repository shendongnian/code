    using System;
    
    namespace Observer
    {
        class Program
        {
            static void Main()
            {
                Employee fred = new Employee()
                {
                    Name = "Fred",
                    Title = "Crane Operator",
                    Salary = 40000.0
                };
    
                TaxMan tax_man = new TaxMan();
                fred.Update += tax_man.OnUpdate;
                fred.Salary = 50000.0;
            }
        }
    
        public class Subject
        {
            public delegate void UpdateHandler(Subject s);
            public virtual event UpdateHandler Update;
        }
    
        public class Employee : Subject
        {
            public string Name { get; set; }
            public string Title { get; set; }
            private double _salary;
            public double Salary
            {
                get { return _salary; }
                set
                {
                    _salary = value;
                    if (Update != null)
                        Update(this);
                }
            }
            public override event UpdateHandler Update;
        }
    
        public class TaxMan
        {
            public void OnUpdate(Subject s)
            {
                if (s is Employee)
                    Console.WriteLine("Send {0} a new tax bill!",
                        (s as Employee).Name);
            }
        }
    
    }
