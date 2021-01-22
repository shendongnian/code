    public bool IsWindowActive(Int32 PID)
    {
      return IsWindowActive(Process.GetProcessById(PID));
    }
    [DllImport("user32.dll")]
    private static extern
    IntPtr GetForegroundWindow();
    public bool IsWindowActive(Process proc)
    {
      proc.Refresh();
      return proc.MainWindowHandle.Equals(GetForegroundWindow());
    }
