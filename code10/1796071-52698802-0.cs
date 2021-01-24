    // Add an appender to a logger
    public void AddAppender(string loggerName,
    log4net.Appender.IAppender appender)
    {
      log4net.ILog log = log4net.LogManager.GetLogger(loggerName);
      log4net.Repository.Hierarchy.Logger l =
    (log4net.Repository.Hierarchy.Logger)log.Logger;
    
      l.AddAppender(appender);
    }
    
    // Find a named appender already attached to a logger
    public log4net.Appender.IAppender FindAppender(string
    appenderName)
    {
      foreach (log4net.Appender.IAppender appender in
    log4net.LogManager.GetRepository().GetAppenders())
      {
        if (appender.Name == appenderName)
        {
          return appender;
        }
      }
      return null;
    }
