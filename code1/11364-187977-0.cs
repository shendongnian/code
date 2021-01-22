    bool processIsRunning(string process)
    {
    System.Diagnostics.Process[] processes = 
        System.Diagnostics.Process.GetProcessesByName(process);
    foreach (System.Diagnostics.Process proc in processes)
    {
        Console.WriteLine("Current physical memory : " + proc.WorkingSet64.ToString());
        Console.WriteLine("Total processor time : " + proc.TotalProcessorTime.ToString());
        Console.WriteLine("Virtual memory size : " + proc.VirtualMemorySize64.ToString());
    }
    return (processes.Length != 0);
    }
