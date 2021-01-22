        var result =
            (from c in Calls group c by c.Date into cg select new {Date = cg.Key, Calls = cg.Count(), Orders = 0})
            .Union(from o in Orders group o by o.Date into og select new {Date = og.Key, Calls = 0, Orders = og.Count()})
            .GroupBy(x => x.Date)
            .Select(g => new {Date = g.Key, Calls = g.Max(r => r.Calls), Orders = g.Max(r => r.Orders)});
        foreach (var row in result)
        {
            Trace.WriteLine(row);
        }
