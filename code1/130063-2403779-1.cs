    public static void GetConfigs()
    {
      //Get the base config directory which is copied over to the output directory (discussed above).
      string directory = HttpContext.Current.Server.MapPath("~/bin/BaseConfig");
      //Get the config value. This is used to determine which file to open.
      string configMode = ConfigurationManager.AppSettings.Get("Config").ToLowerInvariant();
      var config = XElement.Load(string.Format(@"{0}\{1}.AppSettings.config", directory, configMode)
        .Elements("add")
        .Select(x => new { Key = x.Attribute("key").Value, Value = x.Attribute("value").Value })
        //If the current application instance does not contain this key in the config, then add it.
        //This way, we create a form of configuration inheritance.
        .Where(x => ConfigurationManager.AppSettings.Get(x.Key) == null);
      //Now loop through the base config
      foreach (var configSetting in config)
      {
        //Add a new app setting to the configuration.
        ConfigurationManager.AppSettings.Set(configSetting.Attribute("key").Value, configSetting.Attribute("value").Value);
      }
    }
