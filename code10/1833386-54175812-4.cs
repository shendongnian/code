    // Add pairs for each item in the oldSet
    var mergedSet = oldSet.Select(oldItem =>
        new Tuple<Item, Item>(oldItem, newSet.FirstOrDefault(newItem =>
            newItem.id == oldItem.id))).ToList();
    // Add a new pair for each remaining item in the newSet (using null as the first item)
    mergedSet.AddRange(newSet.Where(newItem =>
        mergedSet.All(existingItem => existingItem.Item2?.id != newItem.id))
        .Select(newItem => new Tuple<Item, Item>(null, newItem)));
