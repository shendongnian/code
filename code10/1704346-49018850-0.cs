    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var list1 = new List<string> { "br", "je" };
            var list2 = new List<string> { "banana", "bread", "jam", 
                                           "brisket", "flakes", "jelly" };
    
            var res = list2
                .Select(item => list1.Any(l1 => item.ToLower().Contains(l1.ToLower())));
    
            Console.WriteLine(string.Join(",", list1));
            Console.WriteLine(string.Join(",", list2));
            Console.WriteLine(string.Join(",", res));
    
            Console.ReadLine();
        }
    }
