    public class MyLock : log4net.Appender.FileAppender.MinimalLock
    {
          public override Stream AcquireLock()
          {
                if (CurrentAppender.Threshold == log4net.Core.Level.Off)
                      return null;
    
                return base.AcquireLock();
          }
    }
