    using System;
    using System.Threading;
    class Program
    {
        static void Main()
        {
            using (new Timer(state => Console.WriteLine(state), "Hi!", 0, 5 * 1000))
            {
                Thread.Sleep(60 * 1000);
            }
        }
    }
