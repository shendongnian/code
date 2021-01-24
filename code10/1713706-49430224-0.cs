    public void log( Priority priority, string message)
    {
        string currentLogLevel; // <= This can't work
        _logger = NLog.LogManager.GetLogger(priority.ToString());
        LogEventInfo logEvent = new LogEventInfo(currentLogLevel , _logger.Name, message);
        _logger.Log(logEvent);
    }
