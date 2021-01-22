    using System.Diagnostics;
    
    bool ApplicationAlreadyStarted()
    {
      return Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length == 0;
    }
