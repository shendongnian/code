    /// <summary>
    /// Sets the logging level for log4net.
    /// </summary>
    private static void RemoveEmptyLogFile()
    {
      //Get the logfilename before we shut it down
      log4net.Appender.FileAppender rootAppender = (log4net.Appender.FileAppender)((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.Appenders[0];
      string filename = rootAppender.File;
      //Shut down all of the repositories to release lock on logfile
      log4net.Repository.ILoggerRepository[] repositories = log4net.LogManager.GetAllRepositories();
      foreach (log4net.Repository.ILoggerRepository repository in repositories)
      {
        repository.Shutdown();
      }
      //Delete log file if it's empty
      var f = new FileInfo(filename);
      if (f.Exists && f.Length <= 0)
      {
        f.Delete();
      }
    } // RemoveEmptyLogFile
