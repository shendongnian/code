    public interface ILogTarget
    {
        void Save(string message);
    }
    
    public class LogToFile : ILogTarget
    {
        public void Save(string message)
        {
            //
        }
    }
    
    
    public class LogToConsole : ILogTarget
    {
        public void Save(string message)
        {
            //
        }
    }
    
    public interface ILogger
    {
        void Debug(string message);
    }
    
    public class Logger : ILogger
    {
        private readonly List<ILogTarget> _targets;
        private static Logger _logger;
    
        public Logger(List<ILogTarget> targets)
    	{
            _targets = targets;
        }
    
        public void Debug(string message)
        {
            foreach (var target in _targets)
                target.Save($"Debug: {message}");
        }
    
    }
    
    public class TheClassThatMakesTheCall
    {
        private readonly ILogger _logger;
    
        public TheClassThatMakesTheCall(ILogger logger)
        {
            _logger = logger;
        }
    
        public void AMethod()
        {
            _logger.Debug("some message");
        }
    }
    
    //In your IoC, register Logger as a type of ILogger, and pass in the targets that you want
    //If your target vary per situation, you'll need a ILogTarget factory that returns a different list of loggers based on the situation
