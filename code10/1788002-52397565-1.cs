        public static class Logger
        {
            private static TelemetryClient _logger;
    
            public static void Log(string message)
            {
                _GetLogger().TrackTrace(message);
                _Flush();
            }
    
            public static TelemetryClient _GetLogger()
            {
                if (_logger is null)
                {
                    TelemetryConfiguration.Active.InstrumentationKey = "your key";
                    _logger = new TelemetryClient();
    
                }
    
                return _logger;
    
            }
    
            public static void _Flush()
            {
                if (_logger is null)
                {
                    TelemetryConfiguration.Active.InstrumentationKey = "your key";
                    _logger = new TelemetryClient();
    
                }
    
                _logger.Flush();
            }
    
            public static async Task DoSomethingAsync()
            {
                await Task.Delay(1000);
            }
    
        }
