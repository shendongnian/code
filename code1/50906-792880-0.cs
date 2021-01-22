    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(string.Format("Argument {0}: {1}", i, args[i]));
            }
        }
    }
