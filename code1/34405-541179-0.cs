    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Employee a = new Employee(1);
                Employee b = new Employee(1);
    
                Console.WriteLine("a == b := {0}", a == b);
                Console.ReadLine();
            }
        }
    
        class Employee
        {
            private int id;
    
            public Employee(int id) { this.id = id; }
        }
    }
