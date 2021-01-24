    DateTime utcDate = DateTime.UtcNow;
    var result =
        entries // e.g. context.tableName
        .GroupBy(e => e.username)
        .Select(gr =>
            gr
            .Where(x => x.date < utcDate)
            .OrderByDescending(x => x.date)
            .FirstOrDefault()) // This will give us null for devices that
                               // don't have a status entry before the date
        .AsEnumerable()
        .ToList();
