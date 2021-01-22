    public static IQueryable<T> ToPageOfList<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        return source.Skip(pageIndex * pageSize).Take(pageSize);
    }
    //Example
    var g = (from x in choices select x).ToPageOfList(1, 20);
