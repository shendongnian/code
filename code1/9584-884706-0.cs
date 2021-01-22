    public static extern long OpenIcon(long hwnd);
    [System.Runtime.InteropServices.DllImport("user32")]
    public static extern long SetForegroundWindow(long hwnd);
    public static void ActivateInstance()
    {
        long MyHndl = 0;
        long result = 0;
        Process objProcess = Process.GetCurrentProcess();
        MyHndl = objProcess.MainWindowHandle.ToInt32();
        result = OpenIcon(MyHndl); // Restore the program.
        result = SetForegroundWindow(MyHndl); // Activate the application.
        //System.Environment.Exit(0); // End the current instance of the application.
    }
