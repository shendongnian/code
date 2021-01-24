    public static class ILoggerExtensions
	{
		public static void General(this ILogger logger, string message)
		{
			logger.Log<GeneralLog>(message);
		}
	}
