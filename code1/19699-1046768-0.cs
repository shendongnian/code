    public static T Get<T>(this IDataRecord rec, Func<IDataRecord, int, T> GetValue, int ordinal)
    {
        return rec.IsDBNull(ordinal) ? default(T) : GetValue(rec, ordinal);
    }
            
    public static Func<IDataRecord, int, int> GetInt32 = (rec, i) => rec.GetInt32(i);
    public static Func<IDataRecord, int, bool> GetBool = (rec, i) => rec.GetBoolean(i);
    public static Func<IDataRecord, int, string> GetString = (rec, i) => rec.GetString(i);
