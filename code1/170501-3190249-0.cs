    static void Main()
    {
        if (!EnsureSingleInstance())
        {
            return;
        }
        //...
    }
    static bool EnsureSingleInstance()
    {
        Process currentProcess = Process.GetCurrentProcess();
        string applicationTitle = "APPLICATION-TITLE";
        var runningProcess = (from process in Process.GetProcesses()
                              where
                                process.Id != currentProcess.Id &&
                                process.ProcessName.Equals(currentProcess.ProcessName, StringComparison.Ordinal)
                              select process).FirstOrDefault();
        if (runningProcess != null)
        {
            ShowWindow(runningProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
            SetForegroundWindow(runningProcess.MainWindowHandle);
            return false;
        }
        return true;
    }
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
    private const int SW_SHOWMAXIMIZED = 3;
