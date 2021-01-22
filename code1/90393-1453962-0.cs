    public MyService()
    {
        InitializeComponent();
        SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
    }
    
    void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    {
        if (_isRunning)
        {
            // Pause
        }
    }
