    WqlEventQuery wQuery = 
     new WqlEventQuery("Select * From __InstanceDeletionEvent Within 1 Where TargetInstance ISA 'Win32_Process'");
    
    using (ManagementEventWatcher wWatcher = new ManagementEventWatcher(scope, wQuery))
    {    
      bool stopped = false;
    
      while (stopped == false)
      {
        using (ManagementBaseObject MBOobj = wWatcher.WaitForNextEvent())
        {
          if (((ManagementBaseObject)MBOobj["TargetInstance"])["ProcessID"].ToString() == ProcID)
          {
            // the process has stopped
            stopped = true;
          }
        }
      }
    
      wWatcher.Stop();
    }
