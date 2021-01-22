      public class LoggerTests 
      {
        private ListAppender appender;
        private static LogWriter log;
    
        public void OneTimeSetup()
        {
          appender = new ListAppender();
    
          // Log all source levels
          LogSource mainLogSource = new LogSource("MainLogSource", SourceLevels.All);
          mainLogSource.Listeners.Add(appender);
        
          // All messages with a category of "Error" should be distributed
          // to all TraceListeners in mainLogSource.
          IDictionary<string, LogSource> traceSources = new Dictionary<string, LogSource>();
          traceSources.Add("Error", mainLogSource);
          LogSource nonExistentLogSource = null;    
          log = new LogWriter(new ILogFilter[0], traceSources, nonExistentLogSource,
                            nonExistentLogSource, mainLogSource, "Error", false, false);
        }
    
        public void TestLogging()
        {
          LogEntry le = new LogEntry() { Message = "Test", Severity = TraceEventType.Information };
          le.Categories.Add("Debug");
          log.Write(le);
    
          // we are not setup to log debug messages
          System.Diagnostics.Debug.Assert(appender.LogTable.Count == 0);
    
          le.Categories.Add("Error");
          log.Write(le);
          
          // we should have logged an error
          System.Diagnostics.Debug.Assert(appender.LogTable.Count == 1);
        }
      }
