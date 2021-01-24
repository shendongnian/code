        var eventLog = new EventLog("Security")
        {
            EnableRaisingEvents = true
        };
        eventLog.EntryWritten += EventLog_EntryWritten;
        // .. read existing logs or do other work ..
        private static void EventLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            Console.WriteLine($"received new entry: {e.Entry.Message}");
        }
