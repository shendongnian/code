        // Open App.Config of executable
        System.Configuration.Configuration config =
         ConfigurationManager.OpenExeConfiguration
                    (ConfigurationUserLevel.None);
        // Add an Application Setting.
        config.AppSettings.Settings.Add("BackgroundColour",
                       bkc + " ");
        // Save the changes in App.config file.
        config.Save(ConfigurationSaveMode.Modified);
        // Force a reload of a changed section.
        ConfigurationManager.RefreshSection("appSettings");
