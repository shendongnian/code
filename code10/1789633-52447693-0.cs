    public sealed class GlobalLogger : IDisposable
    {
        private static GlobalLogger Logger;
        private readonly Mutex _lock;
        private string _activityLogPath;
        private const string ActivityLogFileName =  @"activity.log";
        private GlobalLogger()
        {
            _lock = new Mutex(false, ActivityLogFileName);          
        }
        /// <summary> Finds the root path of the MSD, sets up log file. </summary>
        /// <returns>Drive info, or null if not found</returns>
        public static void Init()
        {
            if (null == Logger)
            {
                Logger = new GlobalLogger();
            }
            if (string.IsNullOrEmpty(_activityLogPath))
            {
                Logger._activityLogPath = ActivityLogFileName;
            }
        }
		//
		// Debug 
		//
        public static void DebugWriteLineInfo(object sender, string format, params object[] args)
        {
            DebugWriteMessage(sender, "I", true, format, args);
        }
        public static void DebugWriteLineWarning(object sender, string format, params object[] args)
        {
            DebugWriteMessage(sender, "W", true, format, args);
        }
        public static void DebugWriteLineError(object sender, string format, params object[] args)
        {
            DebugWriteMessage(sender, "E", true, format, args);
        }
        private static void DebugWriteMessage(object sender, string severity, bool writeLine, string format, params object[] args)
        {
			if (writeLine)
			{
				Debug.WriteLine(format);
			}
			else
			{
				Debug.Write(format);
			}     
        }
		//
		// Logging
		//
        private static void Log(string logType, string severity, object sender, string format, params object[] args)
        {
            Init();
            if (Logger._lock.WaitOne(250))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(Logger._activityLogPath, true))
                    {
                        if (logType != "RAW")
                        {
                            sw.Write("{0} {1} {2} ",
                                DateTime.Now,
                                logType,
                                severity);
                        }
                        sw.WriteLine(format, args);
                    }
                }
                finally
                {
                    Logger._lock.ReleaseMutex();
                }
            }
        }
        public static void LogActivityInformation(object sender, string format, params object[] args)
        {
            Log("ACT", "I", sender, format, args);  
        }
        public static void LogActivityWarning(object sender, string format, params object[] args)
        {
            Log("ACT", "W", sender, format, args);  
        }
        public static void LogActivityError(object sender, string format, params object[] args)
        {
            Log("ACT", "E", sender, format, args);  
        }
        public static void LogApplicationInformation(object sender, string format, params object[] args)
        {
            Log("APP", "I", sender, format, args);  
        }
        public static void LogApplicationWarning(object sender, string format, params object[] args)
        {
            Log("APP", "W", sender, format, args);  
        }
        public static void LogApplicationError(object sender, string format, params object[] args)
        {
            Log("APP", "E", sender, format, args);  
        }
        public static void LogSystemInformation(object sender, string format, params object[] args)
        {
            Log("SYS", "I", sender, format, args);  
        }
        public static void LogSystemWarning(object sender, string format, params object[] args)
        {
            Log("SYS", "W", sender, format, args);  
        }
        public static void LogSystemError(object sender, string format, params object[] args)
        {
            Log("SYS", "E", sender, format, args);  
        }
        public static void LogRaw(object sender, string format, params object[] args)
        {
            Log("RAW", string.Empty, sender, format, args);
        }
        public void Dispose()
        {
            if (null != _lock)
            {
                _lock.Close();
            }
        }
    }
}
