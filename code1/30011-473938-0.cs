    public class LogContext: IDisposable
    {
      private readonly Logger _logger;
      private readonly string _context;
      public LogContext(Logger logger, string context){
        _logger = logger;
        _context = context;
        _logger.EnterContext(_context);
      }
      public Dispose(){
        _logger.LeaveContext(_context);
      }
    }
    //...
    
    public void Load(){
      using(new LogContext(logger, "Loading")){
        // perform load
      }
    }
