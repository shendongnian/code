    /// <summary>
    /// Steps through each of the entries in the specified event log and returns any that were written 
    /// after the given point in time. 
    /// </summary>
    /// <param name="logName">The event log to inspect, eg "Application"</param>
    /// <param name="writtenSince">The point in time to return entries from</param>
    /// <param name="type">The type of entry to return, or null for all entry types</param>
    /// <returns>A list of all entries of interest, which may be empty if there were none in the event log.</returns>
    public List<EventLogEntry> GetEventLogEntriesSince(string logName, DateTime writtenSince, EventLogEntryType type)
    {
        List<EventLogEntry> results = new List<EventLogEntry>();
        EventLog eventLog = new System.Diagnostics.EventLog(logName);
        foreach (EventLogEntry entry in eventLog.Entries)
        {
            if (entry.TimeWritten > writtenSince && (type==null || entry.EntryType == type))
                results.Add(entry);
        }
        return results;
    }
