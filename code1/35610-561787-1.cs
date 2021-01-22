    public static T SingleOrSpecifiedDefault<T>(this IEnumerable<T> source,
         Func<T> defaultSelector)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source"); 
        }
        if (defaultSelector == null)
        {
            throw new ArgumentNullException("defaultSelector"); 
        }
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                return defaultSelector();
            }
            T first = iterator.Current;
            if (iterator.MoveNext())
            {
                throw new InvalidOperationException();
            }
            return first;
        }
    }
