    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                PerformanceCounter myAppCpu = 
                    new PerformanceCounter(
                        "Process", "% Processor Time", "OUTLOOK", true);
    
                Console.WriteLine("Press the any key to stop...\n");
                while (!Console.KeyAvailable)
                {
                    double pct = myAppCpu.NextValue();
                    Console.WriteLine("OUTLOOK'S CPU % = " + pct);
                    Thread.Sleep(250);
                }
            }
        }
    }
