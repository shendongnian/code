    //EVENT LOG READER
            string source = @"C:\testev.evtx";
            using (var reader = new EventLogReader(source, PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        Console.WriteLine("{0} {1}: {2}", record.TimeCreated, record.LevelDisplayName, record.FormatDescription());
                    }
                }
            }
    //EVENT LOG
            EventLog eventLog = new EventLog();
            eventLog.Source = "ESENT"; //name of an application
            foreach (EventLogEntry log in eventLog.Entries)
            {
                Console.WriteLine("{0}\n", log.Message);
            }
