     using System.Diagnostics;
     private static DateTime GetStartTime(string processName)
     {
        Process[] processes = 
            Process.GetProcessesByName(processName);
        if (processes.Length == 0) 
           throw new ApplicationException(string.Format(
              "Process {0} is not running.", processName));
        // -----------------------------
        DateTime retVal = DateTime.Now;
        foreach(Process p in processes)
           if (p.StartTime < retVal) 
              retVal = p.StartTime;
        return retVal ;
     }
