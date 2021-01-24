    var existing = collection.Where(predicate);
    foreach(var element in existing)
    {
        collection.Remove(element);
    }
    for(int i = 0; i < existing.Count); ++i)
    {
        collection.Add(newReference);
    }
