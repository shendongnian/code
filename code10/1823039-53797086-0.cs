    List<List<T>> parent = new List<List<T>>();
    for (counter = 0; counter <= group.Count - 2; counter++)
    {
        if (condition)
        {
            var child = new List<T>();
            child.Add(element);
            child.Add(element2);
            parent.Add(child);
        }
    }
