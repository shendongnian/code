    public static class SharedLogger : ILogger
    {
       private static LogWriter _writer = new LogWriter();
       private static object _lock = new object();
       public static void Write(string s)
       {
           lock (_lock)
           {
               _writer.Write(s);
           }
       }
    }
