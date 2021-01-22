    try
    {
      config = (Eagle.Search.SearchSettings)ConfigurationSettings.GetConfig("SearchSettings");
    }
    catch (System.Configuration.ConfigurationException ex)
    {
      syslog.FatalException("Loading search configuration failed, you likely have an error", ex);
      return;
    }
