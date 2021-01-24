    var result = Collection.Aggregate()
     .Match(k => k.Timestamp >= startDate && k.Timestamp < endDate)
     .Group(k => new
        {
          year = k.Timestamp.Year,
          month = k.Timestamp.Month,
          day = k.Timestamp.Day,
          hour = k.Timestamp.Hour,
          minute = k.Timestamp.Minute - (k.Timestamp.Minute % 15)
        },
        g => new { _id = g.Key, count = g.Count() }
      )
      .SortBy(d => d._id)
      .ToList();
    
    foreach (var doc in result)
    {
      //System.Console.WriteLine(doc.ToBsonDocument());
      System.Console.WriteLine(
        new BsonDocument {
          { "_id", new DateTime(doc._id.year, doc._id.month, doc._id.day,
            doc._id.hour, doc._id.minute, 0) },
          { "count", doc.count }
        }
      );
    }
