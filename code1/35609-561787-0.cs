    public static T SingleOrNew<T>(this IEnumerable<T> source) where T : new()
    {
        if (source == null)
        {
            throw new ArgumentNullException("source"); 
        }
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                return new T();
            }
            T first = iterator.Current;
            if (iterator.MoveNext())
            {
                throw new InvalidOperationException();
            }
            return first;
        }
    }
