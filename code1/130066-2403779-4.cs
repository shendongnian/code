    public static void GetConfigs()
    {
      if (configMode == null)
      {
        configMode = ConfigurationManager.AppSettings.Get("Config").ToLowerInvariant();
      }
      //Now load the app settings file and retrieve all the config values.
      var config = XElement.Load(@"{0}\AppSettings.{1}.config".FormatWith(directory, configMode))
        .Elements("add")
        .Select(x => new { Key = x.Attribute("key").Value, Value = x.Attribute("value").Value })
        //If the current application instance does not contain this key in the config, then add it.
        //This way, we create a form of configuration inheritance.
        .Where(x => ConfigurationManager.AppSettings.Get(x.Key) == null);
      foreach (var configSetting in config)
      {
          ConfigurationManager.AppSettings.Set(configSetting.Key, configSetting.Value);
      }
    }
