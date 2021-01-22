    using System.Diagnostics;
    using System.Runtime.InteropServices;
    // Sets the window to be foreground
    [DllImport("User32")]
    private static extern int SetForegroundWindow(IntPtr hwnd);
    
    // Activate or minimize a window
    [DllImportAttribute("User32.DLL")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int SW_SHOW = 5;
    private const int SW_MINIMIZE = 6;
    private const int SW_RESTORE = 9;
    private void ActivateApplication(string briefAppName)
    {
    	Process[] procList = Process.GetProcessesByName(briefAppName);
    
    	if (procList.Length > 0)
    	{
    		ShowWindow(procList[0].MainWindowHandle, SW_RESTORE);
    		SetForegroundWindow(procList[0].MainWindowHandle);
    	}
    }
