    [DllImport("coredll", EntryPoint = "FindWindow")]
    public static extern IntPtr FindWindow(
        [In] string lpClassName,
        [In] string lpWindowName);
    [DllImport("coredll", EntryPoint = "ShowWindow")]
    public static extern bool ShowWindow(
        [In] IntPtr hWnd,
        [In] int nCmdShow);
    [DllImport("coredll", EntryPoint = "EnableWindow")]
    public static extern bool EnableWindow(
        [In] IntPtr hWnd,
        [In] bool bEnable);
    public const int SW_HIDE = 0x0000;
    public const int SW_SHOW = 0x0001;
    public static void HideTaskBar()
    {
       IntPtr hWnd = FindWindow("HHTaskBar", null);
       EnableWindow(hWnd, false);
       ShowWindow(hWnd, Win32.SW_HIDE);
    }
    public static void ShowTaskBar()
    {
       IntPtr hWnd = FindWindow("HHTaskBar", null);
       EnableWindow(hWnd, true);
       ShowWindow(hWnd, Win32.SW_SHOW);
    }
