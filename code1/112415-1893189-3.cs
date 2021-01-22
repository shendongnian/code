    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        class Person
        {
            public int DeptId { get; set; }
            public int Salary { get; set; }
        }
    
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { DeptId = 1, Salary = 10000 });
            persons.Add(new Person { DeptId = 1, Salary = 20000 });
            persons.Add(new Person { DeptId = 1, Salary = 30000 });
            persons.Add(new Person { DeptId = 2, Salary = 40000 });
            persons.Add(new Person { DeptId = 3, Salary = 50000 });
    
            var salaries = persons
                .Where(p => p.DeptId == 1 || p.DeptId == 2)
                .GroupBy(p => p.DeptId)
                .Select(x => new { DeptId = x.Key, TotalSalary = x.Sum(p => p.Salary)});
    
            foreach (var dept in salaries)
                Console.WriteLine("{0}: {1}", dept.DeptId, dept.TotalSalary);
        }
    }
