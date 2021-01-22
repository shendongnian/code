    List<EventLogEntry> remoteAccessLogs = new List<EventLogEntry>();
    	
    	
    	remoteAccessLogs.AddRange(
    	
    		from log in EventLog.GetEventLogs()
    		where log.LogDisplayName.Equals("AAA")
    		from entry in log.Entries.Cast<EventLogEntry>()
    		where entry.Source.Equals("BBB")
    		select entry
    	);
