      public class ListAppender : Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.CustomTraceListener
      {
        private List<string> list = new List<string>();
    
        public override void Write(string message)
        {
        }
    
        public override void WriteLine(string message)
        {
          list.Add(message);
        }
    
        public List<string> LogTable
        {
          get
          {
            return list;
          }
        }
      }
