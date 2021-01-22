    public class ErrorLog
    {
        //Notifications
        public const int NOTIFY_ALPHA = 2000;
        public const int NOTIFY_BETA = 2001;
        public const int NOTIFY_GAMMA = 2002;
      
        public static string[] errMessage = 
            {"Critical Error.",           //2000
             "File not found.",          //2001
             "Unknown Event Action Encountered - "     //2002
            };
        public static string GetErrMsg(int errNum)
        {
            return (errMessage[errNum-2000]);
        }
        private static bool ErrorRoutine(int eventLogId)
        {
            try
            {
		        string eventAppName = "My Application";
		        string eventLogName = "My Apps Events";
                string msgStr = GetErrMsg(eventLogId);  // gets the message associated with the ID from the constant you passed in
                if (!EventLog.SourceExists(eventAppName))
                    EventLog.CreateEventSource(eventAppName, eventLogName);
                EventLog.WriteEntry(eventAppName, msgStr, EventLogEntryType.Error, eventLogId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
