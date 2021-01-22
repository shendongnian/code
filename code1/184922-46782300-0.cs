        foreach (var process in Process.GetProcessesByName("excel")) //whatever you need to close 
        {
            if (process.MainWindowTitle.Contains("test.xlsx"))
            {
                process.Kill();
                break;
            }
        }
