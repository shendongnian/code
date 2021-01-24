    private static Logger InitialiseLog(Target target, string customerName)
    {
        var loggerName = string.IsNullOrEmpty(customerName) ? "globalLog" : customerName;
        var targetAlias = "eventlog_" + loggerName;
        var config = LogManager.Configuration ?? new LoggingConfiguration();
        if (config.FindTargetByName(targetAlias)==null)
        {
            config.AddTarget(targetAlias, target);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, target, loggerName, true):
            if (LogManager.Configuration != null)
               LogManager.ReconfigExistingLoggers();
            else
               LogManager.Configuration = config;
        }
       
        return LogManager.GetLogger(loggerName);
    }
