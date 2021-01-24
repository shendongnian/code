    using System;
    using System.Runtime.Loader;
    using System.Threading;
    
    namespace consoleapp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var _quitEvent = new ManualResetEvent(false);
                AssemblyLoadContext.Default.Unloading += ctx =>
                {
                    System.Console.WriteLine("Unloding fired");
                    _quitEvent.Set();
                };
                System.Console.WriteLine("Waiting for signals");
                _quitEvent.WaitOne();
                System.Console.WriteLine("Received signal gracefully shutting down");
                Console.WriteLine("Hello World!");
            }
        }
    }
