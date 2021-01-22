    public static Boolean IsNullOrEmpty<T>(this ICollection<T> collection)
    {
        return collection == null ? true : collection.Count() == 0;
    }
    public static Boolean IsPopulated<T>(this ICollection<T> collection)
    {
        return collection != null ? collection.Count() > 0 : false;
    }
