    public static void EnsureCount<T>(List<T> list, int count)
    {
        if (list.Count > count)
        {
            return;
        }
        if (list.Capacity < count)
        {
            list.Capacity = count;
        }
        list.AddRange(Enumerable.Repeat(default(T), count-list.Count));
    }
