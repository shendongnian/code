    YourType item = ...; // Whatever should come first.
    var map = objects.ToDictionary(obj => obj.ObjectId);
    var list = new List<YourType>();
    list.Add(item);
    while (item.NextObjectId != null)
    {
        // TODO: Handle missing objects? (Use TryGetValue instead of the indexer)
        item = map[item.NextObjectId];
        list.Add(item);
    }
