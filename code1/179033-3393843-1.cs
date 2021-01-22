    public static bool Any(this System.Collections.IEnumerable source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        return source.GetEnumerator().MoveNext();
    }
