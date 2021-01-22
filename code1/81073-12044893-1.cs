    public static class SomeStaticClass
        {
            private static IKernel _diContainer;
            private static ILogger _logger;
    
            public static void Init(IKernel dIcontainer)
            {
                _diContainer = dIcontainer;
                _logger = _diContainer.Get<ILogger>();
            }
    
    
            public static void Log(string stringToLog)
            {
                _logger.Log(stringToLog);
            }
    
    
        }
