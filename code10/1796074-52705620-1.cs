	public static void SetThreshold(string appenderName, log4net.Core.Level threshold)
		{
			foreach (log4net.Appender.AppenderSkeleton appender in log4net.LogManager.GetRepository().GetAppenders())
			{
				if (appender.Name == appenderName)
				{
					appender.Threshold = threshold;
					break;
				}
			}
		}
