    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    config = ConfigurationManager.OpenExeConfiguration(Path.Combine(@"D:\", "config.exe"));
    foreach (string key in config.AppSettings.Settings.AllKeys)
    {
       string value = config.AppSettings.Settings[key].Value;
       ConfigurationManager.AppSettings.Set(key, value);
    }
