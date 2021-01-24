    using System;
    
    static class Int32Extensions
    {
        // This doesn't do what you might expect it to!
        public static void Increment(this int x)
        {
            x = x + 1;
        }
    }
    
    class Test
    {
        static void Main()
        {
            int x = 10;
            x.Increment();
            Console.WriteLine(x); // Still 10
        }
    }
