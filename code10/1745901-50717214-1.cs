    [DllImport("user32.dll")]
    private static extern bool SetWindowText(IntPtr hWnd, string text);
    private void ChangeEdgeToInternet()
    {
        foreach(Process process in Process.GetProcessesByName("Edge"))
        {
            SetWindowText(process.MainWindowHandle, "Internet");
        }
    }
