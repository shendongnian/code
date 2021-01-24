    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp18
    {
        class Program
        {
            static void Main(string[] args)
            {
                try1();
                try2();
                try3();
                try4();
                Console.WriteLine(" no more ...");
                Console.ReadLine();
            }
            static void try1()
            {
                Console.WriteLine(" try1");
                var db = new Model1();
                var emps = db.Employee
                    .Where(level1 => level1.COR_N_ID == 99)
                    .Where(level2 => db.Employee.Where(level3 => level3.MOTHER == level2.Id).Count() == 0).ToList();
                Console.WriteLine(emps.Count());
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.ReadLine();
            }
            static void try2()
            {
                Console.WriteLine("try2");
                var db = new Model1();
                var emps = db.Employee
                        .Where(level1 => level1.COR_N_ID == 99)
                        .Where(level2 => !db.Employee.Any(level3 => level3.MOTHER == level2.Id)).ToList();
                Console.WriteLine(emps.Count());
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.ReadLine();
            }
            static void try3()
            {
                Console.WriteLine("try3");
                var db = new Model1();
                var emps = db.Employee
                    .Where(level1 => level1.COR_N_ID == 99 && !db.Employee.Any(level2 => level2.MOTHER == level1.Id)).ToList();
                Console.WriteLine(emps.Count());
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.ReadLine();
            }
            static void try4()
            {
                Console.WriteLine("try4");
                var db = new Model1();
                var emps = db.Employee
                        .Where(level1 => !db.Employee.Any(level2 => level2.MOTHER == level1.Id)).ToList();
                Console.WriteLine(emps.Count());
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.ReadLine();
            }
        }
    }
