            EventLog aLog = new EventLog();
            aLog.Log = "Application";
            aLog.MachineName = ".";  // Local machine
            string message = "\'Service started\'";
            foreach (EventLogEntry entry in aLog.Entries)
            {
                if (entry.Source.Equals("tvNZB")
                 && entry.EntryType == EventLogEntryType.Information)
                {
                    if (entry.Message.EndsWith(message))
                    {
                        Console.Out.WriteLine("> " + entry.Message);
                        //do stuff
                    }
                }
            }
