     int count = 0;
     while (true)
     {
          try
          {
               AttemptStuff()
          }
          catch (Exception ex)
          {
               if(count < 10)
               {
                    EventLog.WriteEntry("my service", ex.ToString(), EventLogEntryType.Error);
                    count++;
               }
          }
     }
