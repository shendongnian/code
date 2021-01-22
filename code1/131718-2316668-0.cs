    foreach (var proc in Process.GetProcesses()
                                .OrderBy(proc => proc.Id))
    {
        Console.WriteLine("{0}: {1}", p.Id, p.ProcessName);
    }
