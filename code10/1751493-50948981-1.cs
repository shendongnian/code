    foreach (var pList in System.Diagnostics.Process.GetProcesses())
    {
        if (pList.MainWindowTitle.Contains("Calc"))
        {
            var hWnd = pList.MainWindowHandle;
            System.Diagnostics.Debug.WriteLine("FOUND: " + hWnd);
        }
    }
