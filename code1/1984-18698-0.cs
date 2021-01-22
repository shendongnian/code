    [DllImport("user32.dll")]
    public static extern int SendMessage (IntPtr hWnd, int msg, int Param, System.Text.StringBuilder text);
    
    System.Text.StringBuilder text = new System.Text.StringBuilder(255) ;  // or length from call with GETTEXTLENGTH
    int RetVal = Win32.SendMessage( hWnd , WM_GETTEXT, sb.Capacity, text);
