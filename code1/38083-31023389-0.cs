    string configBase = Settings.Default.ConfigurationBase;
    foreach (SettingsProperty settingsProperty in Settings.Default.Properties)
    {
        if (!settingsProperty.IsReadOnly && settings.Default[settingsProperty.Name] is string)
        {
            Settings.Default[settingsProperty.Name] = ((string)Settings.Default[settingsProperty.Name]).Replace("${ConfigurationBase}", configBase);
        }
    }
