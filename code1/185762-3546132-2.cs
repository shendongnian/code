    public void F(String databaseName)
    {
    }
    
    public class Logger
    {
        public void Log(Action<string> f)
        {
            var databaseName = "";
    
            f(databaseName);
        }
    }
    // Call it like this:
    Logger logger = new Logger(...);
    logger.Log(F);
