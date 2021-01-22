        public static class LoggingObserver
        {
            /// <summary>
            /// Last getted log message
            /// </summary>
            public static string LastLog;
    
            /// <summary>
            /// Last getted exception
            /// </summary>
            public static Exception LastException;
    
            /// <summary>
            /// List of log's processors
            /// </summary>
            public static List<BaseLogging> loggings = new List<BaseLogging>();
    
            /// <summary>
            /// Get Exception and send for log's processors
            /// </summary>
            /// <param name="ex">Exception with message</param>
            public static void AddLogs(Exception ex)
            {
                LastException = ex;
                LastLog = string.Empty;
                foreach (BaseLogging logs in loggings)
                {
                    logs.AddLogs(ex);
                }
            }
    
            /// <summary>
            /// Get message log for log's processors
            /// </summary>
            /// <param name="str">Message log</param>
            public static void AddLogs(string str)
            {
                LastException = null;
                LastLog = str;
                foreach (BaseLogging logs in loggings)
                {
                    logs.AddLogs(str);
                }
            }
    
            /// <summary>
            /// Close all processors
            /// </summary>
            public static void Close()
            {
                foreach (BaseLogging logs in loggings)
                {
                    logs.Close();
                }
            }
        }
