    coll.Reverse().Take(N).Reverse().ToList();
    public static IEnumerable<T> TakeLast(this IEnumerable<T> coll, int N)
    {
        return coll.Reverse().Take(N).Reverse();
    }
