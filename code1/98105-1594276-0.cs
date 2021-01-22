    public static void PushRange<T>(this Stack<T> source, IEnumerable<T> collection)
    {
        foreach (var item in collection)
            source.Push(item);
    }
