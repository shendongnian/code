    public static class LogHelper {
        public static Info(this ILog log, Func<Object> messageProvider) {
            if(log.IsInfoEnabled) { log.Info(messageProvider()); }
        }
    }
