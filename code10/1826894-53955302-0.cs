    EventLog appLogs = new EventLog("Application");
    
    var entries = appLogs.Entries.Cast<EventLogEntry>()
                         .Where(x => x.TimeWritten >= DateTime.Now.AddMinutes(-60))
                         .ToList();
