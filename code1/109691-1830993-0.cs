    var indexedQuery = query.Select((item, i) => new { Index = i + 1, Item = item });
    foreach (var o in indexedQuery)
    {
       Console.WriteLine("{0},{1},{2}", o.Index, o.Item.Color, o.Item.Vehicle);
    }
