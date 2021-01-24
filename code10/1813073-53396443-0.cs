	public static class Log
	{
		private static readonly string LogFileName = "testlog.json";
        private static Object myLock = new Object();
		public static bool IsFileExist => File.Exists(LogFileName);
		public static void WriteLine(string value)
		{
            lock (myLock )
            {
			    File.AppendAllText(LogFileName, value);
            }
		}
		public static string GetLogPath()
		{
			return LogFileName;
		}
	}
