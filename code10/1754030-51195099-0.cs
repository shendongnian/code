    private EventLog _eventLog;
    /*
     * Use the EventId enumeration to store event IDs that will be written with events
     * to the Windows event log.
     */
    enum EventId  
    {
        ServiceStarting = 10,
        ServiceStartNormal = 100,
        ServiceStartFailure = 999;
    }
    protected override void OnStart(string[] args)
    {
        try
        {
            // remember the event log
            _eventLog = EventLog;
            // log start
            LogMessage(_eventLog, "Service starting", EventLogEntryType.Information, EventId.ServiceStarting);
            filePath = configReader.ReadConfig("FilePath");
            DateEvent dateEvent = new DateEvent(DateTime.Now, TimeLoggerCore.Events.STARTUP.ToString());
            writer.WriteToFile(dateEvent, filePath, true, false);
            LogMessage(_eventLog, "Service started", EventLogEntryType.Information, EventId.ServiceStartNormal);
        }
        catch(Exception e)
        {
            LogMessage(_eventLog, e.ToString(), EventLogEntryType.Error, EventId.ServiceStartFailure);
        }
    }
    private static void LogMessage(EventLog eventLog, string message, EventLogEntryType entryType, EventId eventId)
    {
        /*
         * If the event source we want to log doesn't exist, create it.
         * Note that this take admin privs, and creating the log source should be
         * done during service installation.  This is here as a secondary means
         * to create the log in the event that it doesn't already exist.
         */
        if (!EventLog.SourceExists(eventLog.Source)
        {
            EventLog.CreateEventSource(eventLog.Source, eventLog.Log);
        }
        eventLog.WriteEntry(message, entryType, (int) eventId);
    }
