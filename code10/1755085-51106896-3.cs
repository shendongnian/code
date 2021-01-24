    static public Logger.Textlog Logging { get; } = new Logger.Textlog();
    
    public bool MyMethod(Logger.Textlog passedTextLog = null)
    {
    	if (passedTextLog != null) {
    	    Logging = passedTextLog;
    	    Logging.WriteLine(LOG_TRANSACTION, "Here");
    	}
    	
    	...
    }
