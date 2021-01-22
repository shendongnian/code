    private void UpdateAppSettings(string key, string value)
    {
        System.Configuration.Configuration configFile = null;
        if (System.Web.HttpContext.Current != null)
        {
            configFile =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
        }
        else
        {
            configFile =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        var settings = configFile.AppSettings.Settings;
        if (settings[key] == null)
        {
            settings.Add(key, value);
        }
        else
        {
            settings[key].Value = value;
        }
        configFile.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
    }
