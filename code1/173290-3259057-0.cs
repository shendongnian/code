    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> states = new List<string>();
                states.Add("SC");
                states.Add("TX");
                states.Add("NC");
                List<Employee> emps = new List<Employee>();
                emps.Add(new Employee() { State = "GA", Name = "Bill" });
                emps.Add(new Employee() { State = "TX", Name = "John" });
                emps.Add(new Employee() { State = "SC", Name = "Mary" });
                //Here's where the work is done.  The rest is fluff...
                var empsinstates = from e in emps where states.Contains(e.State) select e;
                foreach (var e in empsinstates)
                {
                    Console.WriteLine(e.Name + " " + e.State);
                }
                Console.Read();
            }
        }
        class Employee
        {
            public string State;
            public string Name;
        }
    }
