    [Event(EventType.AppCrashed, Channel = EventChannel.Admin, Message = "Unhandled exception occurred. Details: {0}", Keywords = EventKeywords.None, Level = EventLevel.Critical)]
    private void UnhandledException(string exceptionMsg)
    {
        WriteEvent(EventType.AppCrashed, exceptionMsg, Environment.MachineName);
    }
