    public static void Write(string message, LogCategory logCategory)
    {
        var log = new LogEntry { Message = message };
        Logger.Write(log, logCategory.Value);
    }
