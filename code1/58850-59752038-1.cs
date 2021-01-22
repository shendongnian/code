    string[] eventLogSources = {"Application", "System", "Security"};
    var messagePattern = "*Your Message Search Pattern*";
    var timeStamp = DateTime.Now.AddDays(-4);
    
    var matchingEvents = new List<EventRecord>();
    
    foreach (var eventLogSource in eventLogSources)
    { 
        var i = 0;
        var query = string.Format("*[System[TimeCreated[@SystemTime >= '{0}']]]",
            timeStamp.ToUniversalTime().ToString("o"));
    
        var elq = new EventLogQuery(eventLogSource, PathType.LogName, query);
        var elr = new EventLogReader(elq);
        EventRecord entryEventRecord;
        while ((entryEventRecord = elr.ReadEvent()) != null)
        {
            if ((entryEventRecord.Properties)
                .FirstOrDefault(x => (x.Value.ToString()).Contains(messagePattern)) != null)
            {
                matchingEvents.Add(entryEventRecord);
                i++;
            }
        }
    }
