    [DllImport("user32")]
    internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);
    [DllImport("User32")]
    internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {
         /// <summary>
         /// </summary>            
         public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        
         /// <summary>
         /// </summary>            
         public RECT rcMonitor = new RECT();
        
         /// <summary>
         /// </summary>            
         public RECT rcWork = new RECT();
        
         /// <summary>
         /// </summary>            
         public int dwFlags = 0;
    }
    void Maximize(HWND hWnd, HMONITOR hMonitor)
    {
        // access monitor info
        MONITORINFO monitorInfo = { sizeof(MONITORINFO) };
        GetMonitorInfo(hMonitor, &monitorInfo);
    
        // restore window to normal size if it is not yet
        ShowWindow(hWnd, SW_RESTORE);
    
        // move window to the monitor
        SetWindowPos(hWnd, nullptr, monitorInfo.rcMonitor.left, 
        monitorInfo.rcMonitor.top, 0, 0, SWP_NOZORDER | SWP_NOSIZE);
    
        // maximize window
        ShowWindow(hWnd, SW_MAXIMIZE);    
    }
