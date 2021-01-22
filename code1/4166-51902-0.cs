    // Sets the window to be foreground
    [DllImport("User32")]
    private static extern int SetForegroundWindow(IntPtr hwnd);
    
    // Activate or minimize a window
    [DllImportAttribute("User32.DLL")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int SW_RESTORE = 9;
    
    static void Main()
    {
    	try
    	{
    		// If another instance is already running, activate it and exit
    		Process currentProc = Process.GetCurrentProcess();
    		foreach (Process proc in Process.GetProcessesByName(currentProc.ProcessName))
    		{
    			if (proc.Id != currentProc.Id)
    			{
    				ShowWindow(proc.MainWindowHandle, SW_RESTORE);
    				SetForegroundWindow(proc.MainWindowHandle);
    				return;   // Exit application
    			}
    		}
    
    
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(new MainForm());
    	}
    	catch (Exception ex)
    	{
    	}
    }
