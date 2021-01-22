    using System;
    using System.Diagnostics;
    class Program
    {
    static void Main(string[] args)
    {
        Process[] processess = Process.GetProcesses();//Get all the process in your system
        foreach (var process in processess)
        {
            try
            {
                Console.WriteLine(process.ProcessName);
                process.PriorityClass = ProcessPriorityClass.BelowNormal; //sets all the process to below normal priority
                process.Kill();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message + " :: [ " + process.ProcessName + " ] Could not be killed");
            }
        }
    }
    };
