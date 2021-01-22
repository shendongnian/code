    using System;
    
    public class Test
    {
        static void Main(string[] args)
        {
            Func<bool> x = FirstProvider;
            x += SecondProvider;
            x += ThirdProvider;
            
            Execute(x);
        }
        
        static void Execute(Func<bool> providers)
        {
            foreach (Func<bool> provider in providers.GetInvocationList())
            {
                if (provider())
                {
                    Console.WriteLine("Done!");
                    return;
                }
            }
            Console.WriteLine("No provider succeeded");
        }
        
        static bool FirstProvider()
        {
            Console.WriteLine("First provider returning false");
            return false;
        }
    
        static bool SecondProvider()
        {
            Console.WriteLine("Second provider returning true");
            return true;
        }
    
        static bool ThirdProvider()
        {
            Console.WriteLine("Third provider returning false");
            return false;
        }
    }
