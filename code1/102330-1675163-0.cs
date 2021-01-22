    private void GUI_Load(object sender, EventArgs e)
    {                        
    // Initialize timer to hide application when automatically launched
    _hideTimer = new System.Windows.Forms.Timer();
    _hideTimer.Interval = 0; // 0 Seconds
    _hideTimer.Tick += new EventHandler(_hideTimer_Tick);
    _hideTimer.Enabled = true;
    }
    // Declare timer object
    System.Windows.Forms.Timer _hideTimer;
    void _hideTimer_Tick(object sender, EventArgs e)
    {
        // Disable timer to not use it again
        _hideTimer.Enabled = false;
        // Hide application
        this.HideApplication();
        // Dispose timer as we need it only once when application auto-starts
        _hideTimer.Dispose();
    }
    [DllImport("coredll.dll")]
    static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
    
    const int SW_MINIMIZED = 6;
    
    public void HideApplication()
    {
          ShowWindow(this.Handle, SW_MINIMIZED);
    }
