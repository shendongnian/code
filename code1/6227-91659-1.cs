    namespace Tools.CastleWindsor.Interceptors
    {
    using Castle.Core.Logging;
    public class LoggingInterceptor : AbstractLoggingInterceptor
    {
        public LoggingInterceptor(ILoggerFactory logFactory) : base(logFactory)
        {
        }
    }
    }
