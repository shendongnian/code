    EventLog log = new EventLog("Security");
    var entries = log.Entries.Cast<EventLogEntry>()
                             .Where(x => x.InstanceId == 4624)
                             .Select(x => new
                             {
                                 x.MachineName,
                                 x.Site,
                                 x.Source,
                                 x.Message
                             }).ToList();
