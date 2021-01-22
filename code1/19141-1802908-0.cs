    using System;
    
    public class MyClass
    {
        public static void CtrlCHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Child killed by CTRL+C.");
        }
        public static void Main()
        {
            Console.WriteLine("Child start.");
            Console.CancelKeyPress += CtrlCHandler;
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Child finish.");
        }
    }
