    [Conditional("TRACE")]
    public static void Log(this YourLoggerType logger, string message) {
        if(logger==null) {
           throw new ArgumentNullException("logger",
                "logger was null, logging " + message);
        } else {
           try {
               logger.LogCore(message); // the old method
           } catch (Exception ex) {
               throw new InvalidOperationException(
                    "logger failed, logging " + message, ex);
           }
        }
    }
