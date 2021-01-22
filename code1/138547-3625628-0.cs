    public static IEnumerable<T> CoalesceEmpty<T>(IEnumerable<T> coll)
    {
        if (coll == null)
            return Enumerable.Empty<T>();
        else
             return coll;
    }
