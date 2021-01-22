    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class MyTuple
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            List<MyTuple> tuples = new List<MyTuple>
            {
                new MyTuple { P1 = "A", P2 = "B" },
                new MyTuple { P1 = "A", P2 = "C" },
                new MyTuple { P1 = "D", P2 = "B" },
            };
            
            var query = from tuple in tuples
                orderby tuple.P1
                group tuple.P2 by tuple.P1 into g
                select new { Group = g.Key,
                             Elements = g.OrderByDescending(p2 => p2) };
            
            foreach (var group in query)
            {
                Console.WriteLine("{0}:", group.Group);
                foreach (var value in group.Elements)
                {
                    Console.WriteLine("  {0}", value);
                }
            }
        }
    }
