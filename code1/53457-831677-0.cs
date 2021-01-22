    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, string> map = 
                new SortedDictionary<int, string>();
            map[1] = "Kevin Hazzard";
            Console.WriteLine( map[1] );
            map[1] = "W. Kevin Hazzard";
            Console.WriteLine( map[1] );
            Console.ReadLine();
        }
    }
