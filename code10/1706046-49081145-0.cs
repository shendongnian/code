    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var n = 5;
                var result = Enumerable.Range(0,n*n).GroupBy(k=> k/n).Select(g=> g.Select(k=> (k % n == (n-1-k/n)) ? k%n+1 : 0).ToArray()).ToArray();
                foreach(var r in result)
                {
                    foreach(var a in r)
                    {
                        Console.Write(" {0}", a);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
