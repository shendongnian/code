    using System;
    
    class Program
    {
        static void Foo(int x = 1)
        {
            Console.WriteLine(x);
        }
        
        static void Main()
        {
            Action action = Foo; // Error
            action();
        }
    }
