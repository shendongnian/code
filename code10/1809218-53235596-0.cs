    using Microsoft.Extensions.Logging;
    
    static class MyLogger {
    
        public ILoggerFactory LoggerFactory {get;}
    
        static MyLogger() {
            LoggerFactory = new LoggerFactory();
            LoggerFactory.AddConsole();
        }
    }
    
    public MyClass {
        private readonly ILogger _logger = new Logger<MyClass>(MyLogger.LoggerFactory);
    }
