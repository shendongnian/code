    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, int>();        
            dict.Add(0, 0);
            dict.Add(1, 1);
            dict.Add(2, 2);
            dict.Remove(0);
            dict.Add(10, 10);
            
            foreach (var entry in dict)
            {
                Console.WriteLine(entry.Key);
            }
            Console.WriteLine("First key: " + dict.First().Key);
        }
    }
