    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace IsPangram
    {
        static class Program
        {
            public static bool IsPangram(this string input)
            {
                return
                    !input.ToLower()
                          .Aggregate("abcdefghijklmnopqrstuvwxyz".ToList(),
                                     (ts, c) => ts.Where(x => x != c).ToList())
                          .Any();
            }
            public static void Main(string[] args)
            {
                Console.WriteLine(Console.ReadLine().IsPangram() ?
                                  "Is pangram" :
                                  "Is not pangram");
            }
        }
    }
