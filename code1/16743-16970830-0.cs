    public static T[] ConvertToArray<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null)
            throw new ArgumentNullException("enumerable");
    
        return enumerable as T[] ?? enumerable.ToArray();
    }
