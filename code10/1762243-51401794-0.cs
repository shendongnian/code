    var result = from i in items
                 group i by new
                 {
                   i.Created.Date
                 }
                 into g
                 select new
                 {
                   Date = g.Key,
                   Average = g.Average(p => p.Value)
                 };
