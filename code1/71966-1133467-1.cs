    class EventLogger : ILogger
    {
        public void Debug(string text)
        {
            EventLog.WriteEntry("MyAppName", text, EventLogEntryType.Information);
        }
        public void Warn(string text)
        {
            EventLog.WriteEntry("MyAppName", text, EventLogEntryType.Warning);
        }
        public void Error(string text)
        {
            EventLog.WriteEntry("MyAppName", text, EventLogEntryType.Error);
        }
        public void Error(string text, Exception ex)
        {
            Error(text);
            Error(ex.StackTrace);
        }
    }
