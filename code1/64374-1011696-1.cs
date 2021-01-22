    [DllImport("user32.dll")]
    public static extern int EnumWindows(EnumWindowsCallback x, int y);
    public delegate bool EnumWindowsCallback(int hwnd, int lParam);
    [DllImport("user32.dll")]
    public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);
    [DllImport("user32.dll")]
    public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    private void ContextMenu_Quit_All(object sender, EventArgs ea)
    {
        EnumWindowsCallback itemHandler = (hwnd, lParam) =>
        {
            StringBuilder sb = new StringBuilder(1024);
            GetWindowText(hwnd, sb, sb.Capacity);
            if ((sb.ToString() == MainWindow.APP_WINDOW_TITLE) &&
                (hwnd != mainWindow.Handle.ToInt32())) // Don't close self yet
            {
                PostMessage(new IntPtr(hwnd), /*WM_CLOSE*/0x0010, 0, 0);
            }
            // Continue enumerating windows. There may be more instances to close.
            return true;
        };
        EnumWindows(itemHandler, 0);
        // Close self ..
    }
