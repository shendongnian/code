    Process[] processlist = Process.GetProcesses();
    foreach (Process process in processlist)
    {
        if (!String.IsNullOrEmpty(process.MainWindowTitle) && 
            process.MainWindowTitle.Contains("MyExcel"))
          {
               process.CloseMainWindow();
          }
    }
