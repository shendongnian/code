    [DllImport("Wtsapi32.dll", CharSet=.CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool WTSRegisterSessionNotification(IntPtr hWnd, int dwFlags); 
    //Pass this value in dwFlags
    public const int NOTIFY_FOR_ALL_SESSIONS          =  0x1; 
    //Listen for this message
    public const int WM_WTSSESSION_CHANGE = 0x02B1;
    //Call this method before exiting your program
    [DllImport("Wtsapi32.dll", CharSet=.CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd); 
    //Compare the wParam of the message to these values
    //The lParam is the session ID, which can be passed to various Terminal Services methods.
    public const int WTS_CONSOLE_CONNECT              =  0x1;
    public const int WTS_CONSOLE_DISCONNECT           =  0x2; 
    public const int WTS_REMOTE_CONNECT               =  0x3;
    public const int WTS_REMOTE_DISCONNECT            =  0x4;
    public const int WTS_SESSION_LOGON                =  0x5;
    public const int WTS_SESSION_LOGOFF               =  0x6; 
    public const int WTS_SESSION_LOCK                 =  0x7;
    public const int WTS_SESSION_UNLOCK               =  0x8; 
    public const int WTS_SESSION_REMOTE_CONTROL       =  0x9; 
