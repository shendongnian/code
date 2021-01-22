    var dbQuery =  
        from l in DB.GetLogs()
        from e in l.Entries.DefaultIfEmpty()
        orderby l.Date ascending  
        select new { Date = l.Date, Entry = e };
    var query = dbQuery.AsEnumerable()
                       .Select(x => new { 
                            Date = x.Date,
                            ClockIn = x.Entry == null ? null : x.Entry.CLockIn,
                            ClockOut = x.Entry == null ? null : x.Entry.CLockOut
                        });
