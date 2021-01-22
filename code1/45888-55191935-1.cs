    private Level ToggleLogging(string logLevel)
	{
	    Level level = null;
	    if (logLevel != null)
	    {
	        level = LogManager.GetRepository().LevelMap[logLevel];
	    }
	    
	    if (level == null)
	    {
	        level = Level.Warn;
	    }
	    ILoggerRepository[] repositories = LogManager.GetAllRepositories();
	    //Configure all loggers to be at the same level.
	    foreach (ILoggerRepository repository in repositories)
	    {
	        repository.Threshold = level;
	        Hierarchy hier = (Hierarchy)repository;
	        ILogger[] loggers = hier.GetCurrentLoggers();
	        foreach (ILogger logger in loggers)
	        {
	            ((Logger)logger).Level = level;
	        }
	    }
	    //Configure the root logger.
	    Hierarchy h = (Hierarchy)LogManager.GetRepository();
	    Logger rootLogger = h.Root;
	    rootLogger.Level = level;
	    return level;
	}
