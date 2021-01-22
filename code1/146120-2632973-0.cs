    using System;
    class Program
    {
        static Action GetMethod()
        {
            return () => Console.WriteLine("Executing");
        }
        static void Main()
        {
            GetMethod()();
            Console.ReadKey();
        }
    }
