    var List =  from result in resultList
                group d by new { d.Name, d.Len , d.Height} into g
                select new Connector
                (
                    Id = g.First().ID,
                    Name = g.Key.Name,
                    Len = g.Key.Len,
                    Height = g.Key.Height,
                    count = g.Sum(s => s.Count)
                );
