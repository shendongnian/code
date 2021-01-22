    public static bool Any(this IEnumerable source)
    {
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
        using (IEnumerator enumerator = source.GetEnumerator())
        {
            if (enumerator.MoveNext())
            {
                return true;
            }
        }
        return false;
    }
