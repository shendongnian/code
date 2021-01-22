    public static void AddRange<T, S>(this List<T> list, params S[] values)
        where S : T
    {
        foreach (S value in values)
            list.Add(value);
    }
