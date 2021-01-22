    /// <summary>
    /// The key this is returning must set before the settings are used.
    /// e.g. <c>Properties.Settings.Default.SettingsKey = @"C:\temp\user.config";</c>
    /// </summary>
    private string UserConfigPath
    {
        get
        {
            return Properties.Settings.Default.SettingsKey;
        }
		
    }
