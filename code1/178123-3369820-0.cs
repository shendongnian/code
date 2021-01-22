    using System;
    
    class Program
    {
        static int GetUpperBound()
        {
            Console.WriteLine("GetUpperBound called.");
            return 5;
        }
    
        static void Main(string[] args)
        {
            for (int i = 0; i < GetUpperBound(); i++)
            {
                Console.WriteLine("Loop iteration {0}.", i);
            }
        }
    }
