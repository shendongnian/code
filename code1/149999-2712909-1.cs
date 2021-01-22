    foreach (Process pr in Process.GetProcesses())
    {
         try
         {
             Console.WriteLine("App Name: {0}, Process Name: {1}", Path.GetFileName(pr.MainModule.FileName), pr.ProcessName);
         }
         catch { }
    }
