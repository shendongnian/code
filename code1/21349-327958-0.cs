    using System;
    
    class Foo
    {
        static void Main()
        {
            string[] x = new string[10];
            string[] y = x;
            
            Array.Resize(ref x, 20);
            Console.WriteLine(x.Length); // Prints out 20
            Console.WriteLine(y.Length); // Still prints out 10
        }
    }
