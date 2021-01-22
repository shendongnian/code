    public void EndTask(string taskname)
      {
          string processName = taskname.Replace(".exe", "");
    
          foreach (Process process in Process.GetProcessesByName(processName))
          {
              process.Kill();
          }
      }
    
    //EndTask("notepad");
