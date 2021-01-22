     class EventLogger : ILogger
    {
        public override void InitializeLogger(string Type)
        {
            //Event Logger Initialize   
        }
        public override int WriteLog(string msg)
        {
            //Write to event log
            return 1;
        }
        public override string PrepareLog(System.Exception ex)
        {
          return ex.StackTrace ;
        }
    }
    
    class FileLogger : ILogger
    {
        public override void InitializeLogger(string Type)
        {
        }
        public override int WriteLog(string msg)
        {
            //Write to File
            return 1;
        }
        public override string PrepareLog(System.Exception ex)
        {
          return ex.StackTrace ;
        }
    }
    class MailLogger : ILogger
    {
        public override void InitializeLogger(string Type)
        {
        }
        public override int WriteLog(string msg)
        {
            //Write to mail
            return 1;
        }
        public override string PrepareLog(System.Exception ex)
        {
            //prepare HTML Formatted msg
            return ex.StackTrace ;
        }
    }
