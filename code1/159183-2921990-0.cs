    using System;
    class Foo
    {
        static void Main()
        {
            bool bar = Console.ReadLine() == "bar";
            if (bar)
            {
                Console.WriteLine("bar");
            }
    
            if (true == bar)
            {
                Console.WriteLine("true == bar");
            }
    
            if (bar == true)
            {
                Console.WriteLine("bar == true");
            }
        }
    }
