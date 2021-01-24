    using System;
    namespace tests 
    {
        class Program
        {
            static void Main(string[] args)
            {
                int x = 42;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("White on blue.");
                Console.WriteLine("Another line.");
                Console.ResetColor();
                Console.WriteLine(x);
            }
        }
    }
