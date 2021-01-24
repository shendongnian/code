    var logger = NLog.LogManager.GetLogger("hostLogger");
    var minLogLevel = "Disabled";
    if (logger.IsTraceEnabled)
        minLogLevel = "Trace";
    else if (logger.IsDebugEnabled)
        minLogLevel = "Debug";
    else if (logger.IsInfoEnabled)
        minLogLevel = "Info";
    else if (logger.IsWarnEnabled)
        minLogLevel = "Warn";
    else if (logger.IsErrorEnabled)
        minLogLevel = "Error";
    else if (logger.IsFatalEnabled)
        minLogLevel = "Fatal";
    logger.Info("Minimum Log Level: {0}", minLogLevel)
