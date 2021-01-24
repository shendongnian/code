    using Serilog;
    using Serilog.Core;
    public interface ICustomLogger
    {
        ILogger Log { get; }
    }
    public class CustomLogger : ICustomLogger
    {
        private readonly Logger _logger;
        public ILogger Log { get { return _logger; } }
        public CustomLogger( Logger logger )
        {
            _logger = logger;
        }
    }
