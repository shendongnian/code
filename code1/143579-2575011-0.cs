    public class Test
    {
        
        public static void Main()
        {
            Console.WriteLine("Hello");
    
        
            Console.WriteLine("Sum of even fibonacci {0}", Fibonacci(100).Where(x => x % 2 == 0).Sum());
            Console.WriteLine("Sum of odd fibonacci {0}", Fibonacci(100).Where(x => x % 2 == 1).Sum());
    
            Console.Write("Fibonacci");
            foreach (decimal i in Fibonacci(100))
                Console.Write(" {0}", i);
    
    
        
            
            Console.ReadLine();
    
        }
    
        public static IEnumerable<decimal> Fibonacci(int range)
        {
            int i = 0;
    
            decimal very = 0;
            ++i;
    
            yield return very;
    
            decimal old = 1;
            ++i;
            yield return old;
    
            decimal fib = 0; 
            while (i < range)
            {
                fib = very + old;
    
                yield return fib;
                ++i;
    
                very = old;    
                old = fib;                
            }
    
        }//fibonacci
    }//test
