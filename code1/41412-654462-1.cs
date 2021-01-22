    public static void RemoveAll<T>(this IList<T> list, Func<T, bool> predicate)
    {
        int count = list.Count;
        for (int i = count-1; i > -1; i--)
        {
            if (predicate(list[i]))
            {
                list.RemoveAt(i);
            }
        }
    }
