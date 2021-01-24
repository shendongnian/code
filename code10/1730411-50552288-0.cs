    DateTime startDate = new DateTime(2018, 5, 1, 0, 0, 0, DateTimeKind.Utc);
    DateTime endDate = new DateTime(2018, 6, 1, 0, 0, 0, DateTimeKind.Utc);
    var result = Collection.Aggregate()
      .Match(k => k.Timestamp >= startDate && k.Timestamp < endDate)
      .Group(k =>
        new DateTime(k.Timestamp.Year, k.Timestamp.Month, k.Timestamp.Day,
            k.Timestamp.Hour, k.Timestamp.Minute - (k.Timestamp.Minute % 15), 0),
        g => new { _id = g.Key, count = g.Count() }
      )
      .SortBy(d => d._id)
      .ToList();
