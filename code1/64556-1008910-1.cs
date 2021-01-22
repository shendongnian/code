    using System;
    using System.Threading;
    
    class Launchee
    {
        static void Main()
        {
            Console.WriteLine("       I've been launched!");
            Thread.Sleep(5000);
            Console.WriteLine("       Exiting...");
        }
    }
