    public interface INotificationFactory
    {
        IEnumerable<ILogger> Loggers
        {
           get;
           set; // <- Remove it if it's possible
        }
        void AddLogger(ILogger logger);
        void DoLog(EMsgType msgType, string msg);
        // Remove it if it's possible: Loggers is enough
        IEnumerable<ILogger> GetLoggers();  
    }
