    public static class SingletonLoggingService
    {
        public static ILoggingService LoggingService = ObjectBuilder.GetObjectByName("LoggingService"); 
    }
    
    
    SingletonLoggingService.LoggingService.Info("Test");
