    public class CombinedLogger : ILogger{    
    IList<ILogger> _loggers;    
    public CombinedLogger(params ILogger[] loggers)    
    {         
    _loggers = new List<ILogger>();    
    _loggers.Add(myContainer.Resolve(Of ILogger)("ConsoleLogger")
    _loggers.Add(myContainer.Resolve(Of ILogger)("AnotherLogger")
    }    
    public void Write(string message)    
    {         
    foreach(var logger in _loggers) logger.Write(message);    
    }
    }
