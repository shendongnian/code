    System.Diagnostics;    
    ...
    string thisprocessname = Process.GetCurrentProcess().ProcessName;
    
    if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                    return;
