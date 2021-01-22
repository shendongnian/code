    private void FitToScreen()
    {
    	if (this.Width > Screen.PrimaryScreen.WorkingArea.Width)
    	{
    		this.Width = Screen.PrimaryScreen.WorkingArea.Width;
    	}
    	if (this.Height > Screen.PrimaryScreen.WorkingArea.Height)
    	{
    		this.Height = Screen.PrimaryScreen.WorkingArea.Height;
    	}
    }   
    private void LoadPreferences()
    {
        // Called from Form.OnLoad
    
        // Remember the initial window state and set it to Normal before sizing the form
        FormWindowState initialWindowState = this.WindowState;
        this.WindowState = FormWindowState.Normal;
        this.Size = UserPreferencesManager.LoadSetting("_Size", this.Size);
        _currentFormSize = Size;
        // Fit to the current screen size in case the screen resolution
        // has changed since the size was last persisted.
        FitToScreen();
        bool isMaximized = UserPreferencesManager.LoadSetting("_Max", initialWindowState == FormWindowState.Maximized);
        WindowState = isMaximized ? FormWindowState.Maximized : FormWindowState.Normal;
    }
    private void SavePreferences()
    {
        // Called from Form.OnClosed
        UserPreferencesManager.SaveSetting("_Size", _currentFormSize);
        UserPreferencesManager.SaveSetting("_Max", this.WindowState == FormWindowState.Maximized);
        ... save other settings
    }
