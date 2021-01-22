    public const int GW_HWNDNEXT = 2; // The next window is below the specified window
    public const int GW_HWNDPREV = 3; // The previous window is above
    
    [DllImport("user32.dll")]
    static extern IntPtr GetTopWindow(IntPtr hWnd);
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsWindowVisible(IntPtr hWnd);
    
    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindow", SetLastError = true)]
    public static extern IntPtr GetNextWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.U4)] int wFlag);
    
    /// <summary>
    /// Searches for the topmost visible form of your app in all the forms opened in the current Windows session.
    /// </summary>
    /// <param name="hWnd_mainFrm">Handle of the main form</param>
    /// <returns>The Form that is currently TopMost, or null</returns>
    public static Form GetTopMostWindow(IntPtr hWnd_mainFrm)
    {
        Form frm = null;
    
        IntPtr hwnd = GetTopWindow((IntPtr)null);
        if (hwnd != IntPtr.Zero)
        {
            while ((!IsWindowVisible(hwnd) || frm == null) && hwnd != hWnd_mainFrm)
            {
                // Get next window under the current handler
                hwnd = GetNextWindow(hwnd, GW_HWNDNEXT);
    
                try
                {
                    frm = (Form)Form.FromHandle(hwnd);
                }
                catch
                {
                    // Weird behaviour: In some cases, trying to cast to a Form a handle of an object 
                    // that isn't a form will just return null. In other cases, will throw an exception.
                }
            }
        }
    
        return frm;
    }
