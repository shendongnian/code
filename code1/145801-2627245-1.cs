    public static void Log(this Logger logger, string message)
    {
        if(logger != null)
            logger.ReallyLog(message);
    }
