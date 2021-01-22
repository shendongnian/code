    public static T Get<T>(this IDataRecord row, string fieldName)
    {
        int ordinal = row.GetOrdinal(fieldName);
        return row.Get<T>(ordinal);
    }
    
    public static T Get<T>(this IDataRecord row, int ordinal)
    {
        var value = row.IsDBNull(ordinal) ? default(T) : row.GetValue(ordinal);
        return (T)Convert.ChangeType(value, typeof(T));
    }
