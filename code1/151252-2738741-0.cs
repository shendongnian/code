    public static IEnumerable<string> GetColumnNames(this IDataReader reader)
    {
        for(int i=0; i<reader.FieldCount; i++)
            yield return reader.GetName(i);
    }
