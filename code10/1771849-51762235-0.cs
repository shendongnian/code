    public static void LogEvent(string logBuffer, EventLogEntryType eventLogEntryType)
    {
    	const string source = "DemoTestApplication";
    
    	// The user may not have permissions to access any event logs, therefore catch any SecurityExceptions.
    	try
    	{
    		if (!EventLog.SourceExists(source))
    		{
    			// This requires administrator privileges.
    			EventLog.CreateEventSource(source, "Application");
    		}
    		using (EventLog eventLog = new EventLog())
    		{
    			eventLog.Source = source;
    			eventLog.WriteEntry(logBuffer, eventLogEntryType);
    		}
    	}
    	catch (System.Security.SecurityException ex)
    	{
    		// Source was not found, but some or all of the event logs could not be searched.
    		// May occur e.g., when trying to search Security event log.
    		// EventLog.CreateEventSource requires permission to read all event logs to make sure 
    		// that the new source name is unique.
    		Debug.WriteLine(logBuffer);
    		Debug.WriteLine(ex.ToString());
    	}
    }
