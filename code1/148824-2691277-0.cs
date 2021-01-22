    [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    
    public void SendText(IntPtr hwnd, string keys)
    {
        if (hwnd != IntPtr.Zero)
        {
            if (SetForegroundWindow(hwnd))
            {
                System.Windows.Forms.SendKeys.SendWait(keys);
            }
        }
    }
