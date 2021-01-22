    using System;
    using System.Diagnostics;
    
    namespace ProcessStatus
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process[] processes = Process.GetProcesses();
    
                foreach (Process process in processes)
                {
                    Console.WriteLine("Process Name: {0}, Responding: {1}", process.ProcessName, process.Responding);
                }
    
                Console.Write("press enter");
                Console.ReadLine();
            }
        }
    }
