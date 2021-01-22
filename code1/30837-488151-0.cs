    public void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach ( var o in enumerable )
        {
            action(o);
        }
    }
