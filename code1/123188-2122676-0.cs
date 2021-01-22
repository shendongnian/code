    using System;
    using System.Threading;
    static class Program
    {
        static void Main()
        {
            new Thread(DoActivation).Start();
            Console.WriteLine("Main: waiting for activation");
            activation.WaitOne();
            Console.WriteLine("Main: and off we go...");
        }
        static void DoActivation(object state)
        {
            Console.WriteLine("DoActivation: activating...");
            Thread.Sleep(2000); // pretend this takes a while
            Console.WriteLine("DoActivation: activated");
            activation.Set();
            // any other stuff on this thread...
        }
        static ManualResetEvent activation = new ManualResetEvent(false);
    }
