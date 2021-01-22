    using System;
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Console.WriteLine("Process exiting");
            Environment.Exit(0);
        }
    }
