    public delegate void logDelegate(string str);
    public class Operation
    {
        public event logDelegate EventLogHandler;
        public Operation()
        {
            new FileLog(this);
            new ConsoleLog(this);
        }
    
        public void DoWork()
        {
            EventLogHandler.Invoke("somthing is working");
        }
    }
