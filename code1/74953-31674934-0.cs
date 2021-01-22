    private static void UpdateSetting(string key, string value)
    {
        Configuration configuration = ConfigurationManager.
            OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();
    
        ConfigurationManager.RefreshSection("appSettings");
    }
