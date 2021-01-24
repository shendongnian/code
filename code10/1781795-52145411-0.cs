    public static IEnumerable<TResult> Select<TResult>(this IDataReader reader,
                                           Func<IDataReader, TResult> selector)
    {
        while (reader.Read())
        {
            yield return selector(reader);
        }
    }
