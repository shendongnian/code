    abstract class AbstractLogger:ILogger
    {
        #region ILogger Members
        public virtual string PrepareLog(System.Exception ex)
        {
            return ex.StackTrace;
        }
        public abstract void InitializeLogger(string Type);
        public abstract int WriteLog(string msg);
        #endregion
    }
    class EventLogger : AbstractLogger
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
    }
    
    class FileLogger : AbstractLogger
    {
        public override void InitializeLogger(string Type)
        {
        }
        public override int WriteLog(string msg)
        {
            //Write to File
            return 1;
        }
    }
    class DBLogger : AbstractLogger
    {
        public override void InitializeLogger(string Type)
        {
        }
        public override int WriteLog(string msg)
        {
            //Write to DB
            return 1;
        }
    }
    class MailLogger : AbstractLogger
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
