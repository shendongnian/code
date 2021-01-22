	public static void Initialize()
	{
	
	#if DEBUG
		ConfigureAndWatch();
	#else
		ConfigureAndLockChanges();
	#endif
	
	}
	
	#if DEBUG
	
	private static void ConfigureAndWatch()
	{
		XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));
	}
	
	#else
	
	private static void ConfigureAndLockChanges()
	{
		// Disable using DEBUG mode in Release mode (to make harder to hack)
		XmlConfigurator.Configure(new FileInfo("log4net.config"));
		foreach (ILoggerRepository repository in LogManager.GetAllRepositories())
		{
			repository.Threshold = Level.Warn;
		}
	}
	
	#endif
