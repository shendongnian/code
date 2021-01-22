    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List<Foo>();
                list.Add(new Foo() { id = Guid.Empty, description = "empty" });
                list.Add(new Foo() { id = Guid.Empty, description = "empty" });
                list.Add(new Foo() { id = Guid.NewGuid(), description = "notempty" });
                list.Add(new Foo() { id = Guid.NewGuid(), description = "notempty2" });
    
                var unique = from l in list
                             group l by new { l.id, l.description } into g
                             select g.Key;
                foreach (var f in unique)
                    Console.WriteLine("ID={0} Description={1}", f.id,f.description);
                Console.ReadKey(); 
            }
        }
    
        class Foo
        {
            public Guid id;
            public string description;
        }
    }
