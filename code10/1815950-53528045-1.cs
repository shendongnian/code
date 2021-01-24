    private static Logger InitialiseLog(Target target, string customerName)
    {
        var loggerName = string.IsNullOrEmpty(customerName) ? "globalLog" : customerName;
        var config = LogManager.Configuration ?? new LoggingConfiguration();
        if (config.FindTargetByName("eventlog")==null)
        {
            config.AddTarget("eventlog", target);
            var rule = new LoggingRule("*", LogLevel.Debug, target);
            config.LoggingRules.Add(rule);
            LogManager.Configuration = config;
        }
       
        return LogManager.GetLogger(loggerName);
    }
