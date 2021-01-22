    public void Each<T>(IEnumerable<T> items, Action<T> action)
    {
        foreach (var item in items)
            action(item);
    }
