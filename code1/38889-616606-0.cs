    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Process.GetCurrentProcess().ProcessName);
            Console.ReadLine();
        }
    }
