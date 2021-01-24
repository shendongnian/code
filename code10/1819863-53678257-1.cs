    private static IList<ProcessInfo> BuildProcessDictionary()
    {
      var wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process";
      using (var searcher = new ManagementObjectSearcher(wmiQueryString))
      using (var results = searcher.Get())
      {
        var processList = from p in Process.GetProcesses()
                          join mo in results.Cast<ManagementObject>()
                          on p.Id equals (int)(uint)mo["ProcessId"]
                          select new ProcessInfo
                          {
                            Process = p,
                            Path = (string)mo["ExecutablePath"],
                            DisplayName = (string)mo["ExecutablePath"]!=null?FileVersionInfo.GetVersionInfo((string)mo["ExecutablePath"]).FileDescription:string.Empty
                          };
                    return processList.ToList();
       }
       return default;
     }
     public class ProcessInfo
     {
       public string Path { get; set; }
       public string DisplayName { get; set; }
       public Process Process { get; set; }
     }
