    public static IEnumerable<T> ToEnumerable<T>(this T item)
    {
        return new T[] { item };
    }
    all.Except(exceptions).Except(otherException.ToEnumerable());
