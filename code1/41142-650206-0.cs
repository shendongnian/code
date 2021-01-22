    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
    if (0 < rootWebConfig1.AppSettings.Settings.Count)
    {
      System.Configuration.KeyValueConfigurationElement customSetting = 
      rootWebConfig1.AppSettings.Settings["customsetting1"];
      if (null != customSetting) {
        Console.WriteLine("customsetting1 application string = \"{0}\"",                  customSetting.Value);
      }
      else {
        Console.WriteLine("No customsetting1 application string");
      }
    }
