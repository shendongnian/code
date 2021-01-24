    EventLog log = new System.Diagnostics.EventLog("Application");
    int cutoff = 100;
    var events = new List<EventLogEntry>();
    for (int i = log.Entries.Count - 1; i >= 0; i--) {
        // note that line below might throw ArgumentException
        // if, for example, entries were deleted in the middle
        // of our loop. That's rare condition, but robust code should handle it
        var next = log.Entries[i];
        if (next.EntryType == EventLogEntryType.Error) {
            // add what you need here
            events.Add(next);
            // got as much as we need, break
            if (events.Count == cutoff)
                break;
        }
    }
