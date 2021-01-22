    public static string GetDefaultExeConfigPath(ConfigurationUserLevel userLevel)
    {
      try
      {
        var UserConfig = ConfigurationManager.OpenExeConfiguration(userLevel);
        return UserConfig.FilePath;
      }
      catch (ConfigurationException e)
      {
        return e.Filename;
      }
    }
