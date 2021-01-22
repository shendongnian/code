    public static T Next<T>(this IList<T> list, T item)
    {
        var nextIndex = list.IndexOf(item) + 1;
        if (nextIndex == list.Count)
        {
            return list[0];
        }
        return list[nextIndex];
    }
