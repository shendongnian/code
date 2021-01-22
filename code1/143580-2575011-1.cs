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
            Console.WriteLine("Hello");
    
        
            IntX even = 0;
            foreach(IntX i in Fibonacci(1000).Where(x => x % 2 == 0))
                even += i;
    
            Console.WriteLine("Sum of even fibonacci {0}", even);
    
            IntX odd = 0;
            foreach (IntX i in Fibonacci(1000).Where(x => x % 2 == 1))
                odd += i;
    
            
            Console.WriteLine("\nSum of odd fibonacci {0}", odd);
    
    
            Console.Write("\nFibonacci samples");
            foreach (IntX i in Fibonacci(20))
                Console.Write(" {0}", i);
    
    
        
            
            Console.ReadLine();
    
        }
    
        public static IEnumerable<IntX> Fibonacci(int range)
        {
            int i = 0;
    
            IntX very = 0;
            ++i;
    
            yield return very;
    
            IntX old = 1;
            ++i;
            yield return old;
    
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
    }
