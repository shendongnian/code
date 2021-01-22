    public class LogHelper 
    { 
         public static Info(ILog log, Object message) 
         { 
              if(log.IsInfoEnabled) 
              { 
                log.Info(message); 
              } 
         } 
    } 
