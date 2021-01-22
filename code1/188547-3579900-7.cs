    const int WM_GETTEXT = 0xD;
    // used for an output LPCTSTR parameter on a method call
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct STRINGBUFFER
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szText;
    }
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr FindWindowEx(IntPtr parent /*HWND*/, 
                                             IntPtr next /*HWND*/, 
                                             string sClassName,  
                                             IntPtr sWindowTitle);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hWnd">handle to destination window</param>
    /// <param name="msg">message</param>
    /// <param name="wParam">first message parameter</param>
    /// <param name="lParam"second message parameter></param>
    /// <returns></returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd,
        int msg, int wParam, out STRINGBUFFER ClassName);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetWindowText(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetClassName(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);
    //[DllImport("user32.dll")]
    //[return: MarshalAs(UnmanagedType.Bool)]
    //static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
    public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);
    
    [DllImport("user32.Dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);
    /// <summary>
    /// Helper to get window classname
    /// </summary>
    /// <param name="hWnd"></param>
    /// <returns></returns>
    static public string GetClassName(IntPtr hWnd)
    {
        NativeWIN32.STRINGBUFFER sLimitedLengthWindowTitle;
        NativeWIN32.GetClassName(hWnd, out sLimitedLengthWindowTitle, 256);
        return sLimitedLengthWindowTitle.szText;
    }
    /// <summary>
    /// Helper to get window text
    /// </summary>
    /// <param name="hWnd"></param>
    /// <returns></returns>
    static public string GetWindowText(IntPtr hWnd)
    {
        NativeWIN32.STRINGBUFFER sLimitedLengthWindowTitle;
        SendMessage(hWnd, WM_GETTEXT, 256, out sLimitedLengthWindowTitle);
        //NativeWIN32.GetWindowText(hWnd, out sLimitedLengthWindowTitle, 256);
        return sLimitedLengthWindowTitle.szText;
    }
 
