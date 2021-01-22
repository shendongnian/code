    public StringBuilder GetLogMessage(LogEventType logType, object message)
    {
    	StringBuilder logEntry = new StringBuilder();
        logEntry.AppendFormat("DATE={0} ", DateTime.Now.ToString("dd-MMM-yyyy", new CultureInfo(CommonConfig.EnglishCultureCode)));
    	//...
    	
    	this.AddMessageDetail(logEntry);
    	logEntry.AppendFormat("MESSAGE={0} ", message);
    	return logEntry;
    }
    
    protected virtual void AddMessageDetail(StringBuilder logMessage)
    {
    }
