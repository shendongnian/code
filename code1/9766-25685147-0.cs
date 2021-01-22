    if (xlApp != null)
    {
        xlApp.Workbooks.Close();
        xlApp.Quit();
    }
        
    System.Diagnostics.Process[] processArray = System.Diagnostics.Process.GetProcessesByName("EXCEL");
    foreach (System.Diagnostics.Process process in processArray)
    {
        if (process.MainWindowTitle.Length == 0) { process.Kill(); }
    }
