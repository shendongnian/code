    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> me)
    {
        return me ?? new List<T>();
    }
    DirectoryHelper.FindAll().EmptyIfNull().foreach
