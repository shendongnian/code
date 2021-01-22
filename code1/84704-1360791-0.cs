    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern bool SetWindowPos(
          IntPtr hWnd, // window handle
          IntPtr hWndInsertAfter, // placement-order handle
          int X, // horizontal position
          int Y, // vertical position
          int cx, // width
          int cy, // height
          uint uFlags); // window positioning flags
    public const uint SWP_NOSIZE = 0x1;
    public const uint SWP_NOMOVE = 0x2;
    public const uint SWP_SHOWWINDOW = 0x40;
    public const uint SWP_NOACTIVATE = 0x10;
    [DllImport("user32.dll", EntryPoint = "GetWindow")]
    public static extern IntPtr GetWindow(
          IntPtr hWnd,
          uint wCmd);
    public const uint GW_HWNDFIRST = 0;
    public const uint GW_HWNDLAST = 1;
    public const uint GW_HWNDNEXT = 2;
    public const uint GW_HWNDPREV = 3;
    public static void ControlSendToBack(IntPtr control)
    {
        bool s = SetWindowPos(
              control,
              GetWindow(control, GW_HWNDLAST),
              0, 0, 0, 0,
              SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
    }
