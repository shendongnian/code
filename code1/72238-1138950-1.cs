    public bool killProcess(int pid)
     {
      bool didIkillAnybody = false;
      try
      {
       Process[] procs = Process.GetProcesses();
       for (int i = 0; i < procs.Length; i++)
       {
        didIkillAnybody = GetParentProcess(procsIdea.Id) == pid) &&
                                       killProcess(procsIdea.Id);
       }
       try
       {
        Process myProc = Process.GetProcessById(pid);
        myProc.Kill();
        return true;
       }
       catch { }
      }
      catch (Exception ex)
      {
       try
       {
        new Logger().Write("Exception caught at JobExecution.killProcess()", ex.Message, System.Diagnostics.EventLogEntryType.Warning, false);
       }
       catch { }
      }
      return didIkillAnybody;
     }
    
     private int GetParentProcess(int Id)
     {
      int parentPid = 0;
      using (ManagementObject mo = new ManagementObject("win32_process.handle='" + Id.ToString() + "'"))
      {
       mo.Get();
       parentPid = Convert.ToInt32(mo["ParentProcessId"]);
      }
      return parentPid;
     }
