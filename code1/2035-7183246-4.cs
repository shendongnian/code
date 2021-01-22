    [DllImport("user32.dll")]
    private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
    private const int SW_SHOWMAXIMIZED = 3;
    static void Main() 
    {
        Process currentProcess = Process.GetCurrentProcess();
        var runningProcess = (from process in Process.GetProcesses()
                              where
                                process.Id != currentProcess.Id &&
                                process.ProcessName.Equals(
                                  currentProcess.ProcessName,
                                  StringComparison.Ordinal)
                              select process).FirstOrDefault();
        if (runningProcess != null)
        {
            ShowWindow(runningProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
           return; 
        }
    }
