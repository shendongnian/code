    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    static extern bool OpenIcon(IntPtr hWnd);
    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    public static void ActivateInstance()
    {
        IntPtr hWnd = IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;
        // Restore the program.
        bool result = OpenIcon(hWnd); 
        // Activate the application.
        result = SetForegroundWindow(hWnd);
        // End the current instance of the application.
        //System.Environment.Exit(0);    
    }
