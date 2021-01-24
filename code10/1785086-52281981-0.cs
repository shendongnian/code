    public void Include(Serilog.ILogger logger)
    {
        Serilog.Events.LogEventLevel logEventLevel = Serilog.Events.LogEventLevel.Debug;
    
        _ = Serilog.Log.ForContext("", "", false);
        _ = Serilog.Context.LogContext.PushProperty("", "", false);
        _ = !logger.IsEnabled(logEventLevel);
        logger.Write(logEventLevel, "", new object[0]);
        logger.Write(logEventLevel, new Exception(), "", new object[0]);
    }
