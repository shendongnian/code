    [Event((int)EventType.AppCrashed, Channel = EventChannel.Admin, Message = "Unhandled exception occurred. Details: {0}", Keywords = EventKeywords.None, Level = EventLevel.Critical)]
    private void UnhandledException(string exceptionMsg)
    {
      WriteEvent(601, exceptionMsg, Environment.MachineName);
    }
    
