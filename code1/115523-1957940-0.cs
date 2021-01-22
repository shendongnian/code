    using System;
    using System.Collections.Generic;
    public class Fibonacci
    {
        public static int Calculate( int x )
        {
            if (x <= 1)
                return 1;
            else
                return Calculate(x - 1) + Calculate(x - 2);
        }
      
        public static void Main()
        {
         Console.WriteLine(Calculate(4));
        }
    }
