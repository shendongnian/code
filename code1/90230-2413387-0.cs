    public static IEnumerable<IEnumerable<T>> SplitEvery<T>(this IEnumerable<T> values, int n)
    {
        var ls = values.Take(n);
        var rs = values.Skip(n);
        return ls.Any() ?
            Cons(ls, SplitEvery(rs, n)) : 
            Enumerable.Empty<IEnumerable<T>>();
    }
    
    public static IEnumerable<T> Cons<T>(T x, IEnumerable<T> xs)
    {
        yield return x;
        foreach (var xi in xs)
            yield return xi;
    }
