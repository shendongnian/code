    public static void AddRange<T>(this List<T> list, params T[] values)
    {
        foreach (T value in values)
            list.Add(value);
    }
