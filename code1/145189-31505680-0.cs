    public static T Get<T>(this IDataRecord row, string fieldName)
    {
        int ordinal = row.GetOrdinal(fieldName);
        return row.Get<T>(ordinal);
    }
    
    public static T Get<T>(this IDataRecord row, int ordinal)
    {
        return (T)Convert.ChangeType(row.GetValue(ordinal), typeof(T));
    }
