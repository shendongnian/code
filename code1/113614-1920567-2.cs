    public static IEnumerable<T> Plus<T>(this IEnumerable<T> collection, T item)
    {
        return collection.Concat(new T[] { item });
    }
    all.Except(exceptions.Plus(otherException))
