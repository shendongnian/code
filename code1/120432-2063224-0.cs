    public void MainLoop()
    {
            // Hook the application’s idle event
            System.Windows.Forms.Application.Idle += new EventHandler(OnApplicationIdle);
            System.Windows.Forms.Application.Run(myForm);
    }    
    
    private void OnApplicationIdle(object sender, EventArgs e)
    {
        while (AppStillIdle)
        {
             // Render a frame during idle time (no messages are waiting)
             UpdateEnvironment();
             Render3DEnvironment();
        }
    }
    
    private bool AppStillIdle
    {
         get
        {
            NativeMethods.Message msg;
            return !NativeMethods.PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
         }
    }
        
    //And the declarations for those two native methods members:        
    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr hWnd;
        public WindowMessage msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }
    
    [System.Security.SuppressUnmanagedCodeSecurity] // We won’t use this maliciously
    [DllImport(“User32.dll”, CharSet=CharSet.Auto)]
    public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);
