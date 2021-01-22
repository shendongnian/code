    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // first
                string[,] arr1 = {
                           { "aa", "aaa" },
                           { "bb", "bbb" }
                       };
    
                // second
                string[][] arr2 = new[] { 
                    new[] { "aa", "aaa" }, 
                    new[] { "bb", "bbb" } 
                };
    
                // iterate through first
                for (int x = 0; x <= arr1.GetUpperBound(0); x++)
                    for (int y = 0; y <= arr1.GetUpperBound(1); y++)
                        Console.Write(arr1[x, y] + "; ");
    
                Console.WriteLine(Environment.NewLine);
    
                // iterate through second second
                foreach (string[] entry in arr2)
                    foreach (string element in entry)
                        Console.Write(element + "; ");
    
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Press any key to finish");
                Console.ReadKey();
            }
        }
    }
