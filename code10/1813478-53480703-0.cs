    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private static bool keepRunning = true;
    
            public static void Main(string[] args)
            {
                Console.WriteLine("Main started");
    
                Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                    e.Cancel = true;
                    keepRunning = false;
                };
    
                while (keepRunning)
                {
                    Console.WriteLine("Doing really evil things...");
    
                    System.Threading.Thread.Sleep(3000);
                }
    
                Console.WriteLine("Exited gracefully");
            }
        }
    }
