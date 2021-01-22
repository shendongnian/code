    public class Logger : ILogger
    {
        public Logger(IFoo foo) { }
        // ...
    }
    [Export(typeof(ILoggerFactory))]
    public class LoggerFactory : ILoggerFactory
    {
        [Import]
        public IFoo Foo { get; set; }
        public ILogger CreateLogger()
        {
            return new Logger(Foo);
        }
    }
