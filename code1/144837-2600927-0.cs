    using System.Diagnostics;
    using System.Linq;
    public static Process GetProcessByName(string processName)
    {  
        return Process
                 .GetProcesses()
                 .FirstOrDefault(p => p.ProcessName == processName);
    }
