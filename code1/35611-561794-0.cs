    public static T SingleOrNew<T>(this IEnumerable<T> query) where T : new()
    {
        try
        {
            return query.Single();
        }
        catch (InvalidOperationException)
        {
            return new T();
        }
    }
