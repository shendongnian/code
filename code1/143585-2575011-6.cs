    using System;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    
    using Oyster.Math;
    
    namespace Application
    {
    
    
    public class Test
    {
        
        public static void Main()
        {    
            IntX even = 0;
            Console.WriteLine("Sum of even fibonacci {0}\n", 
                Fibonacci(20).Where(x => x % 2 == 0).Sum());
            Console.WriteLine("Sum of odd fibonacci {0}", 
                Fibonacci(20).Where(x => x % 2 == 1).Sum());
    
            Console.Write("\nFibonacci samples");
            foreach (IntX i in Fibonacci(20))
                Console.Write(" {0}", i);
              
            Console.ReadLine();
    
        }
    
        public static IEnumerable<IntX> Fibonacci(int range)
        {
            int i = 0;
    
            IntX very = 0;       
            yield return very;
            ++i;
    
            IntX old = 1;       
            yield return old;
            ++i;
    
            IntX fib = 0; 
            while (i < range)
            {
                fib = very + old;
                yield return fib;
                ++i;
    
                very = old;
                old = fib;                
            }
    
        }
    }
    
    
    public static class Helper
    {
        public static IntX Sum(this IEnumerable<IntX> v)
        {
            int s = 0;
            foreach (int i in v) s += i;
            return s;
        }
    }
    
    }
