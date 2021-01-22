    public MainWindow()
    {
    	InitializeComponent();
    
    	// have some timer to fire in every 1 second
    	DispatcherTimer detectShowDesktopTimer = new DispatcherTimer();
    	detectShowDesktopTimer.Tick += new EventHandler(detectShowDesktopTimer_Tick);
    	detectShowDesktopTimer.Interval = new TimeSpan(0, 0, 1);
    	detectShowDesktopTimer.Start();
    }
    
    #region support immunizing against "Show Desktop"
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
    
    private string GetWindowText(IntPtr handle)
    {
    	int chars = 256;
    	StringBuilder buff = new StringBuilder(chars);
    	if (GetWindowText(handle, buff, chars) > 0)
    		return buff.ToString();
    	else
    		return string.Empty;
    }
    #endregion
    
    private void detectShowDesktopTimer_Tick(object sender, EventArgs e)
    {
    	IntPtr fore = GetForegroundWindow();
    	if (string.IsNullOrWhiteSpace(GetWindowText(fore)))
    		ShowDesktopDetected();
    }
    
    private void ShowDesktopDetected()
    {
    	WindowInteropHelper wndHelper = new WindowInteropHelper(this);
    	SetForegroundWindow(wndHelper.Handle);
    }
