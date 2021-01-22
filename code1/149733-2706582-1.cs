    using System;
    using MiscUtil;
    
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(StaticRandom.Next());
            }
        }
    }
