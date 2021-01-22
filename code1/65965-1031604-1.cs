    using System;
    using System.Diagnostics;
    namespace Test
    {
        class TestEventLog
        {
            static void Main(string[] args)
            {
                string source = "MyApplication";
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source,"Application");
                }
                EventLog.WriteEntry(source, "Here is an event-log message");
            }
        }
    }
        
