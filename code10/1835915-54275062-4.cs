    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    namespace stackoverflow305092
    {   
        class Program
        {
            static void Main(string[] args)
            {
                var db = new Model1();
                var emps = db.Employee
                .Where(level1 => !db.Employee.Any(level2 => level2.MOTHER == level1.ID))
                    .ToList();
                Console.WriteLine($"ID \t MOTHER \t NAME");
                foreach (var emp in emps)
                {
                    Console.WriteLine($"{emp.ID} \t {emp.MOTHER}  \t \t {emp.NAME}");
                }
                Console.ReadLine();
            }
        }
        public class Model1 : DbContext
        {
            public Model1() : base("data source=.;initial catalog=stackoverflow54275000;integrated security=True;") { }
            public virtual DbSet<Employee> Employee { get; set; }
        }
        [Table("Employee")]
        public class Employee
        {
            public int ID { get; set; }
            public int? MOTHER { get; set; }
            public string NAME { get; set; }
        }
        //    CREATE TABLE[dbo].[Employee]
        //    (
        //      [ID][int] NOT NULL,
        //     [MOTHER] [int] NULL,
        //	   [NAME] [nvarchar] (250) NOT NULL
        //    )  
    }
