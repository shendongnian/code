    public static void EndTask(string taskname)
      {
      string processName = taskname;
    
      if (taskname.Contains(".exe"))
      {
      string fixstring = taskname.Replace(".exe", "");
      foreach (Process process in Process.GetProcessesByName(fixstring);)
      {
      process.Kill();
      }
      }
      else if (!taskname.Contains(".exe"))
      {
      foreach (Process process in Process.GetProcessesByName(processName))
      {
      process.Kill();
      }
      }
      else
      {
    
      }
      }
    
    //EndTask("notepad");
