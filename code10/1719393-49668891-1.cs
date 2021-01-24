    using System;
    namespace ConsoleAppX
    {
        class D
        {
            static void Foo(ref int y)
            {
                //y = 1;
                y = y + 1; // Mutate y
            }
    
           // static int x;
            static void Main(string[] args)
            {
                int x = 0;
                Foo(ref x);
                Foo(ref x);
                Foo(ref x);
                Console.WriteLine(x);
                Console.ReadLine();
            }
        }
    }
