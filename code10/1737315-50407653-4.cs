    // query Application log, only entries with Level = 2 (that's error)
    var query = new EventLogQuery("Application", PathType.LogName, "*[System/Level=2]");
    // reverse default sort, by default it sorts oldest first
    // but we need newest first (OrderByDescending(x => x.TimeGenerated)
    query.ReverseDirection = true;            
    var events = new List<EventLogInfo>();
    // analog of Take
    int cutoff = 100;
    using (var reader = new EventLogReader(query)) {
        while (true) {
            using (var next = reader.ReadEvent()) {
                if (next == null)
                    // we are done, no more events
                    break;
                events.Add(new EventLogInfo {
                    Id = next.Id,
                    Source = next.ProviderName,
                    Timestamp = next.TimeCreated,
                    Message = next.FormatDescription()
                });
                cutoff--;
                if (cutoff == 0)
                    // we are done, took as much as we need
                    break;
            }
        }
    }
