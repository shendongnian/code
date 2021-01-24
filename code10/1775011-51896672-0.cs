    using System;
    
    class Program
    {
        static void Method(Action action)
        {
            Console.WriteLine("Action");
        }
        
        static void Method(Func<int> func)
        {
            Console.WriteLine("Func<int>");
        }
    
        static void ThrowException()
        {
            throw new Exception();
        }
    
        static void Main()
        {
            // Resolvse to the Action overload
            Method(() => ThrowException());
            // Resolves to the Func<int> overload
            Method(() => { throw new Exception(); });        
        }
    }
