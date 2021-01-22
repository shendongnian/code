    public static IEnumerable<T> Select<T>(this DataReader reader,
                                           Func<DataReader, T> projection)
    {
        while (drOutput.Read())
        {
            yield return projection(reader);
        }
    }
