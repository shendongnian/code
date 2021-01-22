    public void ChangeAppSettings(string applicationSettingsName, string newValue)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
        KeyValueConfigurationElement element = config.AppSettings.Settings[applicationSettingsName];
    
        if (element != null)
        {
            element.Value = newValue;
        }
        else
        {
            config.AppSettings.Settings.Add(applicationSettingsName, newValue);
        }
    
        config.Save(ConfigurationSaveMode.Modified, true);
    
        ConfigurationManager.RefreshSection("appSettings");
    }
