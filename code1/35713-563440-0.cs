    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Threading;
    
    class EventLogEntryCollection_Item
    {
        /// <summary>
        /// Prints all.
        /// </summary>
        /// <param name="myEventLogEntryCollection">My event log entry collection.</param>
        private static void PrintAll(EventLogEntryCollection myEventLogEntryCollection)
        {
            for (int i = 0; i < myEventLogEntryCollection.Count; i++)
            {
                Console.WriteLine("The Message of the EventLog is :"
                   + myEventLogEntryCollection[i].Message);
            }
        }
    
        /// <summary>
        /// Creates the new log message.
        /// </summary>
        /// <param name="LogName">Name of the log.</param>
        /// <param name="message">The message.</param>
        private static void CreateNewLogMessage(string LogName, string message)
        {
            EventLog myEventLog = new EventLog();
            myEventLog.Source = LogName;
            myEventLog.WriteEntry(message);
            myEventLog.Close();
        }
    
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            try
            {
                
                // Check if the source exists.
                if (!EventLog.SourceExists("MySource"))
                {
                    // Create the source.
                    // An event log source should not be created and immediately used.
                    // There is a latency time to enable the source, it should be created
                    // prior to executing the application that uses the source.
                    EventLog.CreateEventSource("MySource", "MySource");
                    Console.WriteLine("Creating EventSource");
                    Console.WriteLine("Exiting, execute the application a second time to use the source.");
                    Thread.Sleep(2000);
                    // The source is created.  sleep to allow it to be registered.
                }
                string myLogName = EventLog.LogNameFromSourceName("MySource", ".");
    
                // Create a new EventLog object.
                EventLog myEventLog1 = new EventLog();
                myEventLog1.Log = myLogName;
    
                //Create test messages.
                myEventLog1.Clear();
                for (int i = 0; i < 20; i++)
                {
                    CreateNewLogMessage("MySource", "The entry number is " + i);
                }
    
                // Obtain the Log Entries of "MyNewLog".
                EventLogEntryCollection myEventLogEntryCollection =
                   myEventLog1.Entries;
                //myEventLog1.Close();
                Console.WriteLine("The number of entries in 'MyNewLog' = "
                   + myEventLogEntryCollection.Count);
    
                // Copy the EventLog entries to Array of type EventLogEntry.
                EventLogEntry[] myEventLogEntryArray =
                   new EventLogEntry[myEventLogEntryCollection.Count];
                myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0);
    
                Console.WriteLine("before deleting");
                // Display the 'Message' property of EventLogEntry.
                PrintAll(myEventLogEntryCollection);
    
                myEventLog1.Clear();
    
                Console.WriteLine("process deleting");
                foreach (EventLogEntry myEventLogEntry in myEventLogEntryArray)
                {
                    //Console.WriteLine("The LocalTime the Event is generated is "
                    // + myEventLogEntry.TimeGenerated + " ; " + myEventLogEntry.Message);
                    if (myEventLogEntry.Index % 2 == 0)
                    {
                        CreateNewLogMessage("MySource", myEventLogEntry.Message);
                    }
                }
    
                Console.WriteLine("after deleting");
                PrintAll(myEventLogEntryCollection);
    
                myEventLog1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }
            Console.ReadKey();
        }
    }
