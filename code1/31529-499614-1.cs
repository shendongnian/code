    var callStats = (from c in database.CallLogs
                     group c by c.RemoteParty into d
                     select new
                     {
                          RemoteParty = d.Key,
                          TotalDuration = d.Sum(x => x.Duration)
                     });
    callStats = callStats.OrderBy( (a,b) => a.TotalDuration > b.TotalDuration )
                         .FirstOrDefault();
     
