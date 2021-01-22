    public static bool TryFirst(this IEnumerable<T> source, out T value)
    {
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                value = default(T);
                return false;
            }
            value = iterator.Current;
            return true;
        }
    }
