    if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
    {
      AppLog.Write("Application XXXX already running. Only one instance of this application is allowed", AppLog.LogMessageType.Warn);
      return;
    }
           
