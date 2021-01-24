      var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var settings = configFile.AppSettings.Settings;
        if (settings["RunnedOnce"] == null)
        {
            settings.Add("RunnedOnce", "1");
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            Application.Run(new Form1());
        }
        else
        {
            Application.Run(new Form2());
        }
