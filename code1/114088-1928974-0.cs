     using System.Diagnostics;
     private static DateTime GetStartTime(string processName)
     {
         Process[] processes = 
            Process.GetProcessesByName(processName);
        DateTime retVal = null;
        foreach(Process p in processes)
           if (p.StartTime < retVal) 
             retVal = p.StartTime;
        return retVal ;
     }
