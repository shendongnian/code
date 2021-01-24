    public static int AddRangeEx<T>(this List<T> target, IEnumerable<T> items)
    {
        int result = items.Count();
        if( result > 0 ) target.AddRange(items);
        return result;
    }
