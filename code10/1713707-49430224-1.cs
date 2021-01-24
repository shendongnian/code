    public void log( Priority priority, string message)
    {
        LogLevel logLevel;
        switch(priority)
        {
            case Priority.Priority1 : loglevel = LogLevel.Error; break;
            case Priority.Priority2 : loglevel = LogLevel.Warn; break;
            case Priority.Priority3 : loglevel = LogLevel.Debug; break;
            case Priority.Priority4 : loglevel = LogLevel.Trace; break;
            default: loglevel = LogLevel.None; break;
        }
        _logger = NLog.LogManager.GetLogger(priority.ToString());
        LogEventInfo logEvent = new LogEventInfo(logLevel , _logger.Name, message);
        _logger.Log(logEvent);
    }
