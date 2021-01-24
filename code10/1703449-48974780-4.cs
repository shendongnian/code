    private static readonly Func<LogMessage,LogMessage> doNothing = m => m;
    public LogMessage Log(string logLevel, string message, Func<LogMessage,LogMessage> preprocess = doNothing) {
        LogMessage logMessage = new LogMessage {
            Message = message,
            LogLevel = logLevel,
            DateTime = DateTime.UtcNow
        };
        OnMessage?.Invoke(this, new LogMessageCreatedEventArgs {
            LogMessage = preprocess(logMessage)
        });
        return logMessage;
    }
