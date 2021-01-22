    public static IEnumerable<T> IntersectAllIfEmpty<T>(params IEnumerable<T>[] lists)
    {
        IEnumerable<T> results = null;
        lists = lists.Where(l => l.Any()).ToArray();
        if (lists.Length > 0)
        {
            results = lists[0];
            for (int i = 1; i < lists.Length; i++)
                results = results.Intersect(lists[i]);
        }
        else
        {
            results = new T[0];
        }
        return results;
    }
