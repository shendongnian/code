    using System;
    
    class Example
    {
        static void Main()
        {
            Console.WriteLine(default(Int32)); // Prints "0"
            Console.WriteLine(default(Boolean)); // Prints "False"
            Console.WriteLine(default(String)); // Prints nothing (because it is null)
        }
    }
