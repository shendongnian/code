    List<TimeEntry> TimeEntryProcessing()
    {
        var entries = new List<TimeEntry>
        {
            new TimeEntry{ entrydate= 1540364988, name= "Time1", timespent=  "0:30"},
            new TimeEntry{ entrydate = 1540304400, name= "Time2", timespent=  "0:25"},
            new TimeEntry{ entrydate = 1540307400, name= "Time1", timespent=  "0:10"},
            new TimeEntry{ entrydate = 1540300010, name= "Time3", timespent=  "0:40"},
            new TimeEntry{ entrydate = 1540365000, name= "Time1", timespent=  "1:10"},
            new TimeEntry{ entrydate = 1540367500, name= "Time3", timespent=  "0:20"},
            new TimeEntry{ entrydate = 1540354500, name=  "Time4", timespent=  "0:30"}
        };
        return entries
            .GroupBy(x => new { x.name, date = TrimUnixTimestampToDate(x.entrydate) })
            .Select(x =>
            {
                var time = AddTimespans(x.Select(y => ToTimeSpan(y.timespent)));
                return new TimeEntry
                {
                    entrydate = x.Key.date,
                    name = x.Key.name,
                    timespent = $"{(int)time.TotalHours}:{time.Minutes}"
                };
            })
            // in case you need an order... you didn't mention it
            .OrderBy(x => x.entrydate).ThenBy(x => x.name)
            .ToList();
    }
    TimeSpan AddTimespans(IEnumerable<TimeSpan> enumerable)
    {
        return new TimeSpan(enumerable.Sum(x => x.Ticks));
    }
    TimeSpan ToTimeSpan(string timespent)
    {
        var parts = timespent.Split(':');
        return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
    }
    int TrimUnixTimestampToDate(int entrydate)
    {
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return (int)dtDateTime.AddSeconds(entrydate).Date.Subtract(dtDateTime).TotalSeconds;
    }
