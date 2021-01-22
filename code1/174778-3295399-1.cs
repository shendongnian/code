    var groups =
      from person in list.WithAdjacentGrouping()
      group person by person.GetType().Name into g
      select new { 
        Type = g.Key,
        Since = new DateTime(g.Select(p => p.Since.Ticks).Min()),
        Until = new DateTime(g.Select(p => p.Until.Ticks).Max())
      }
