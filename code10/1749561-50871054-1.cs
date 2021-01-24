    public class Logger : ILogger
        {
            #region Properties   
            private readonly ILog log;   //ILog refers to interface from log4net library
    
            //Singleton Instance of Logger Class
            private static readonly object threadLock = new Object();
            private static Lazy<Logger> instance;
    
            public static Logger Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (threadLock)
                        {
                            instance = new Lazy<Logger>(() => new Logger());
                            return instance.Value;
                        }
                    }
                    else
                    {
                        return instance.Value;
                    }
                }
            }
    
            #endregion
    
            #region Constructor
            //Private constructor to restrict from any instance creation
            private Logger()
            {
                XmlConfigurator.Configure();
                log = LogManager.GetLogger(GetType());
                //log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
            #endregion
    
            #region Methods
            public void Info(string message)
            {
                log.Info(message);
            }
    
            public void Warn(string message)
            {
                log.Warn(message); 
            }
    
            public void Debug(string message)  
            { 
                log.Debug(message);
            }
    
            public void Error(string message)
            {
                log.Error(message);
            }
    
            public void Error(Exception exception)
            {
                log.Error(exception);
            }
    
            public void Fatal(string message)
            {
                log.Fatal(message);
            }
            #endregion
        }
