    using (EventLog eventLog = new EventLog("Application")) 
    {
        eventLog.Source = "Application"; 
        eventLog.WriteEntry("Log message test", EventLogEntryType.Information, 101, 1); 
    }
