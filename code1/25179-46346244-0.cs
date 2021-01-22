    public static Process GetParent(this Process process)
    {
      try
      {
        using (var query = new ManagementObjectSearcher(
          "SELECT * " +
          "FROM Win32_Process " +
          "WHERE ProcessId=" + process.Id))
        {
          return query
            .Get()
            .OfType<ManagementObject>()
            .Select(p => Process.GetProcessById((int)(uint)p["ParentProcessId"]))
            .FirstOrDefault();
        }
      }
      catch
      {
        return null;
      }
    }
