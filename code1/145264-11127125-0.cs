    private static long CurrentMemoryUsage(Process proc)
    {
      long currentMemoryUsage;
      var nameToUseForMemory = GetNameToUseForMemory(proc);
      using (var procPerfCounter = new PerformanceCounter("Process", "Working Set - Private", nameToUseForMemory))
      {
        //KB is standard
        currentMemoryUsage = procPerfCounter.RawValue/1024;
      }
      return currentMemoryUsage;
    }
    private static string GetNameToUseForMemory(Process proc)
    {
      if (processId2MemoryProcessName.ContainsKey(proc.Id))
        return processId2MemoryProcessName[proc.Id];
      var nameToUseForMemory = String.Empty;
      var category = new PerformanceCounterCategory("Process");
      var instanceNames = category.GetInstanceNames().Where(x => x.Contains(proc.ProcessName));
      foreach (var instanceName in instanceNames)
      {
        using (var performanceCounter = new PerformanceCounter("Process", "ID Process", instanceName, true))
        {
          if (performanceCounter.RawValue != proc.Id) 
            continue;
          nameToUseForMemory = instanceName;
          break;
        }
      }
      if(!processId2MemoryProcessName.ContainsKey(proc.Id))
        processId2MemoryProcessName.Add(proc.Id, nameToUseForMemory);
      return nameToUseForMemory;
    }
