        static System.Diagnostics.EventLog log = new EventLog("System");
        public Form1()
        {
            log.EntryWritten += new EntryWrittenEventHandler(log_EntryWritten);
            log.EnableRaisingEvents = true;
        }
        void log_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            if (e.Entry.InstanceId == 1 && e.Entry.EntryType == EventLogEntryType.Information)
                Console.WriteLine("Test");
        }
