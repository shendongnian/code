    var query = from p in Collection.AsQueryable()
                where p.Timestamp >= startDate && p.Timestamp < endDate
                group p by new DateTime(p.Timestamp.Year, p.Timestamp.Month, p.Timestamp.Day,
                  p.Timestamp.Hour, p.Timestamp.Minute - (p.Timestamp.Minute % 15), 0) into g
                orderby g.Key
                select new { _id = g.Key, count = g.Count() };
