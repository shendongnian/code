    public static void ForEachRow<T>(this T[,] list, Action<int, IEnumerable<T>> action)
    {
        var len = list.GetLength(0);
        var sub = list.GetLength(1);
        int i, j;
        IEnumerable<T> e;
        for (i = 0; i < len; i++)
        {
            e = Enumerable.Empty<T>();
            for (j = 0; j < sub; j++)
            {
                e = e.Concat(AsEnumerable(list[i, j]));
            }
            action(i, e);
        }
    }
    private static IEnumerable<T> AsEnumerable<T>(T add)
    {
        yield return add;
    }
