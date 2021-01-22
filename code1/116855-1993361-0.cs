    public class ConcreteLogger : ILogger
    {
     
        public LogMessage(string message)
        {
            Log.Write(message);
        }
    }
