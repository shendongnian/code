    using System;
    using System.Diagnostics;
    ...
    ...
    public void WriteToEventLog(EventLogEntryType eventLogType, string message, string logSourceName)
    {
        if (!EventLog.SourceExists(logSourceName))
        {
            EventLog.CreateEventSource(logSourceName, "Application");
        }
        using (var eventLog = new EventLog { Source = logSourceName })
        {
            const int maxLength = 31000;
            if (message.Length > maxLength)
            {
                message = message.Substring(0, maxLength);
            }
            eventLog.WriteEntry(message, eventLogType);
        }
    }
