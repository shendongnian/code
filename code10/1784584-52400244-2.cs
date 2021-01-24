    using Hangfire;
    using Hangfire.Logging;
        
    public class NoLoggingProvider : ILogProvider {
        public ILog GetLogger(string name) {
    	    return new NoLoggingLogger();
        }
    }
    
    public class NoLoggingLogger : ILog {
        public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception = null) {
    	    return false;
        }
    }
