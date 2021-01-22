    private void KillProcessAndChildren(int pid)
    {
      ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
      ManagementObjectCollection moc = searcher.Get();
      foreach (ManagementObject mo in moc)
      {
        KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
      }
      try
      {
        Process proc = Process.GetProcessById(pid);
        proc.Kill();
      }
      catch (ArgumentException)
      { /* process already exited */ }
     }
