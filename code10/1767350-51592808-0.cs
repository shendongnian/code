    System.Configuration.Configuration _Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    int lCount;
    if (int.TryParse(ConfigurationManager.AppSettings["count"], out lCount))
    {
         lCount++;
    	_Config.AppSettings.Settings["count"].Value = lCount.ToString();
    	_Config.Save(ConfigurationSaveMode.Modified);
    	ConfigurationManager.RefreshSection(_Config.AppSettings.SectionInformation.Name);
    }
