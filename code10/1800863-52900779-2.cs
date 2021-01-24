    var group = items.GroupBy(g => new {
        g.Field1,
        g.Filed2,
        g.Field3
    })
    .Select(g => g.SelectMany(i => Enumerable.Range(0, i.Duration).Select(d => new { ItemDate = i.ItemDate.AddDays(d), i }))
