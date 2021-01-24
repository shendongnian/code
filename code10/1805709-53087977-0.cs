    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        static class Program
        {
            public static void Main()
            {
                List<string> list1 = new List<string>{"A", "B", "C", "D", "E"};
                List<string> list2 = new List<string>{"D", "E", "F", "G", "H"};
                var inList1ButNotList2 = list1.Except(list2);
                var inList2ButNotList1 = list2.Except(list1);
                var inBothLists        = list1.Intersect(list2);
                Console.WriteLine("In list1 but not list2 = " + string.Join(", ", inList1ButNotList2));
                Console.WriteLine("In list2 but not list1 = " + string.Join(", ", inList2ButNotList1));
                Console.WriteLine("In both lists          = " + string.Join(", ", inBothLists));
            }
        }
    }
