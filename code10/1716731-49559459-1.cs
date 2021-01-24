    var source = new List<Entry>();
    foreach(var p in singleNameWithOldestPrice )
    {
    source.Add(new Entry(p)
    {
        Label = "name of every label",
        ValueLabel = p,
        Color = Color.Red
    })
    }
