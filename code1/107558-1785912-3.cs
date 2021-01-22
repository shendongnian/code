    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        public static bool IsPalindromic(long l)
        {
            IEnumerable<char> forwards = l.ToString().ToCharArray();
            return forwards.SequenceEqual(forwards.Reverse());
        }
    
        public static void Main()
        {
            long n = 0;
            while (true)
            {
                if (IsPalindromic(n))
                    Console.WriteLine("" + n);
                n++;
            }
        }
    }
