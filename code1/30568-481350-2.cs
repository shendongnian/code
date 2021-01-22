    public static void EnsureCount<T>(List<T> list, int count)
    {
        if (list.Count > count)
        {
            return;
        }
        if (list.Capacity < count)
        {
            // Always at least double the capacity, to reduce
            // the number of expansions required
            list.Capacity = Math.Max(list.Capacity*2, count);
        }
        list.AddRange(Enumerable.Repeat(default(T), list.Capacity-list.Count));
    }
