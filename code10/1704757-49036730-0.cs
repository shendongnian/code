    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keyFun) {
        //		return src.GroupBy(keyFun).Select(g => g.FirstOrDefault());  // to defer execution
        var seenKeys = new HashSet<TKey>();
        foreach (T e in src)
            if (seenKeys.Add(keyFun(e)))
                yield return e;
    }
