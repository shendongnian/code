    public static T Last<T>(this IEnumerable<T> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                throw new InvalidOperationException("Empty sequence");
            }
            T value = iterator.Current;
            while (iterator.MoveNext())
            {
                value = iterator.Current;
            }
            return value;
        }
    }
