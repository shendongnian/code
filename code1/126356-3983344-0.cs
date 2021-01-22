    public static IEnumerable<TDest> CastAll<TItem, TDest>(this IEnumerable<TItem> items)
    {
     var p = Expression.Parameter(typeof(TItem), "i");
     var c = Expression.Convert(p, typeof(TDest));
     var ex = Expression.Lambda<Func<TItem, TDest>>(c, p).Compile();
     foreach (var item in items)
     {
        yield return ex(item);
     }
    }
