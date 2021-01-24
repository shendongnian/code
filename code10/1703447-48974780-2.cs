    public static event LogMessageCreatedEventHandler OnMessage;
    // By default message preprocessor does nothing
    public static Func<LogMessage,LogMessage> Preprocess { get; set; } = m => m;
    public LogMessage Log(string logLevel, string message) {
        LogMessage logMessage = new LogMessage {
            Message = message,
            LogLevel = logLevel,
            DateTime = DateTime.UtcNow
        };
        OnMessage?.Invoke(this, new LogMessageCreatedEventArgs {
            LogMessage = Preprocess(logMessage)
        });
        return logMessage;
    }
