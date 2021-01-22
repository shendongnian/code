    public IEnumerable<T> GetFilteredItems(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        if (Matches<T>(item))
        {
            yield return item;
        }
    }
