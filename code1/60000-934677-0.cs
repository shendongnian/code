    using System;
    using System.Reflection;
    using System.Threading;
    
    public class Test
    {
        private static int count = int.MaxValue-1;
        
        public static uint IncrementCount()
        {
            int newValue = Interlocked.Increment(ref count);
            return (uint) newValue;
        }
        
        public static void Main()
        {
            Console.WriteLine(IncrementCount());
            Console.WriteLine(IncrementCount());
            Console.WriteLine(IncrementCount());
        }
            
    }
