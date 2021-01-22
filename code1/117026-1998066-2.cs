    using System;
    
    class Test
    {
        static void SampleMethod<T>(T item, Action<T> printer)
        {
            // You'd do all your normal stuff here
            printer(item);
        }
        
        static void Print(string x)
        {
            Console.WriteLine("Here's a string: {0}", x);
        }
        
        static void Print(int x)
        {
            Console.WriteLine("Here's an integer: {0}", x);
        }
    
        static void Main()
        {
            SampleMethod(5, Print);
            SampleMethod("hello", Print);
        }
    }
