    using System;
    using System.Reflection;
    
    class Test
    {   
        static void Main()
        {
            Delegate[] delegates = new Delegate[]
            {
                (Action<int>) (x => Console.WriteLine("int={0}", x)),
                (Action<string>) (x => Console.WriteLine("string={0}", x)),
                (Action<long>) (x => Console.WriteLine("long={0}", x)),
            };
            
            foreach (dynamic del in delegates)
            {
                // Yay for dynamic binding
                PerformAction(del);
            }
        }
        
        public static void PerformAction<T>(Action<T> action)
        {
            Console.WriteLine("Performing action with type {0}", typeof(T).Name);
            action(default(T));
        }
    }
