    using System.Diagnostics;
    
    public bool IsProcessOpen(string name)
    {
        foreach (Process clsProcess in Process.GetProcesses()) {
            if (clsProcess.ProcessName.Contains(name))
            {
                return true;
            }
        }
        return false;
    } 
