    using System;
    using System.Diagnostics;
    using System.Linq;
    
    namespace TestApp
    {
        class Program
        {
            static void ListAllRunningProcesses()
            {
                // Get all the processes on the local machine, ordered by
                // PID.
                var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
                // Print out PID and name of each process.
                foreach (var p in runningProcs)
                {
                    string info = $"-> PID: {p.Id}\tName: {p.ProcessName}";
                    Console.WriteLine(info);
                }
                Console.WriteLine("************************************\n");
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine("***** Fun with Processes *****\n");
                ListAllRunningProcesses();
                Console.ReadLine();
            }
        }
    }
