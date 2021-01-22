    public static IEnumerable<IDataRecord> AsEnumerable(this IDataReader reader)
    {
        while (reader.Read())
        {
            yield return reader;
        }
    }
