    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            Action first = CreateDelegate(1);
            Action second = CreateDelegate(1);
            first();
            first();
            first();
            first();
            second();
            second();
        }
        
        private static Action CreateDelegate(int x)
        {
            return delegate 
            { 
                Console.WriteLine(x);
                x++;
            };
        }
    }
