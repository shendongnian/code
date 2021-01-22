    if (ckeckInstalled("example"))
    {
        int count = Process.GetProcessesByName("example").Count();
        if (count < 1)
            Process.Start("example.exe");
        else
        {
            var proc = Process.GetProcessesByName("example").FirstOrDefault();
            if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
            {
                SetForegroundWindow(proc.MainWindowHandle);
                ShowWindowAsync(proc.MainWindowHandle, 3);
            }
        }
    }
