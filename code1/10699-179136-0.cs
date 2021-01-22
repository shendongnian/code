    // Open App.Config of executable
    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    // Add an Application Setting with a name Key and a Value stored in variable called Value
    config.AppSettings.Settings.Add("Key", Value );
    
    // Save the changes in App.config file.
    config.Save(ConfigurationSaveMode.Modified);
