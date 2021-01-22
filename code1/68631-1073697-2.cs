    static List<Process> GetChildPrecesses(int parentId) {
      var query = "Select * From Win32_Process Where ParentProcessId = "
              + parentId;
      ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
      ManagementObjectCollection processList = searcher.Get();
      var result = processList.Select(p =>
        Process.GetProcessById(Convert.ToInt32(p.GetPropertyValue("ProcessId")));
      ).ToList();
      return result;
    }
