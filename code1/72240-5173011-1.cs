    private void KillProcessAndChildren(int pid)
    {
      using (var searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid))
      using (ManagementObjectCollection moc = searcher.Get())
      {
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
    }
