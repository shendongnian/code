    var source = new List<Entry>();
    foreach(var p in singleNameWithOldestPrice )
    {
    source.Add(new Entry(p.PRICE)
    {
        Label = p.NAME,
        ValueLabel = p.PRICE,
        Color = Color.Red
    })
    }
