    string query = “Select * From Win32_Process Where Name = “ + processName;
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
    ManagementObjectCollection processList = searcher.Get();
    
    foreach (ManagementObject obj in processList)
    {
         string cmdLine = obj.GetPropertyValue("CommandLine").ToString();
    
         if (cmdLine == "target command line options")
         {
              // do work
         }
    }
