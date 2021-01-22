    List<Process> result = Process.GetProcesses()
                  .Where(p => p.WorkingSet64 > 20 * 1024 * 1024)
                  .OrderByDescending(p => p.WorkingSet64).ToList();
        
    foreach(Process process in result) 
    {
      Console.WriteLine(process.ProcessName);
    }
