    List<Item> oldSet = new List<Item>
    {
        new Item {id = 1, result = "old"},
        new Item {id = 2, result = "old"},
        new Item {id = 3, result = "old"},
    };
    List<Item> newSet = new List<Item>
    {
        new Item {id = 2, result = "new"},
        new Item {id = 3, result = "new"},
        new Item {id = 4, result = "new"},
    };
    var mergedSet = new List<Tuple<Item, Item>>();
    // Add pairs for each item in the oldSet
    foreach (var item in oldSet)
    {
        Item match = newSet.FirstOrDefault(i => i.id == item.id);
        mergedSet.Add(new Tuple<Item, Item>(item, match));
    }
    // Add a new pair for each remaining item in the newSet (using null as the first item)
    foreach (var orphan in newSet.Where(newItem =>
        mergedSet.All(existingItem => existingItem.Item2?.id != newItem.id)))
    {
        mergedSet.Add(new Tuple<Item, Item>(null, orphan));
    }
    foreach (var pair in mergedSet)
    {
        Console.WriteLine("{0}, {1}",
            pair.Item1?.ToString() ?? "[null]",
            pair.Item2?.ToString() ?? "[null]");
    }
