    public class SharedLogger : ILogger
    {
       public static SharedLogger Instance = new SharedLogger();
       public void Write(string s)
       {
          lock (_lock)
          {
             _writer.Write(s);
          }
       }
       private SharedLogger()
       {
           _writer = new LogWriter();
       }
       private object _lock;
       private LogWriter _writer;
    }
