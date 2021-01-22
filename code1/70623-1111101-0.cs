    using System.Diagnostics;
    
    
    class LogSample{
       
       public static void Main()
       {
          // let's create our application log file
          if (!EventLog.SourceExists("ApplicationLog"))
          {
             EventLog.CreateEventSource("ApplicationLog", "SampleLog");
          }
    
          EventLog log = new EventLog();
          log.Source = "ApplicationLog";
    
          // Here we can write the "categories" you require
          log.WriteEntry("Some error entry goes here", EventLogEntryType.Error);
    
          log.Close();
    
          // where EventLogEntryType enum has "Error", "Warning", "Information"
          // we are done with the event log ... forever (ie. we don't want it on the machine)
          log.Delete("ApplicationLog");
       }
    }
