    public class NotificationFactory : INotificationFactory
    {
        // backing field: List<T> is by far more convenient than IEnumerable<T>
        private List<ILogger> m_Loggers = new List<ILogger>();  
    
        // Read-only: we don't want someone change the collection and removing items from it:
        public IReadOnlyList<ILogger> Loggers { 
            get {
                return m_Loggers;
            } 
        }
    
        // The only way to add an item - logger - is this direct call  
        public void AddLogger(ILogger logger)
        {
            if (null == logger)
                throw new ArgumentNullException(nameof(logger));
    
            // Just adding a logger - nothing to write home about
            m_Loggers.Add(logger);
        }
    
        public void DoLog(EMsgType msgType, string msg)
        {
            foreach (var logger in m_Loggers)
            {
                logger.Write(msgType, msg);
            }
        }
    
        //TODO: Do you want it? Loggers property seems to be enough
        public IEnumerable<ILogger> GetLoggers()
        {
            return m_Loggers;
        }
    }
