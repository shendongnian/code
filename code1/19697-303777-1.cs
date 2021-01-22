    public static T GetData<T>(this IDataReader reader, Func<int, T> getFunc, int index)
    {
        if (!reader.IsClosed)
        {
            return getFunc(index);
        }
        throw new ArgumentException("Reader is closed.", "reader");
    }
    public static T GetDataNullableRef<T>(this IDataReader reader, Func<int, T> getFunc, int index) where T : class
    {
        if (!reader.IsClosed)
        {
            return reader.IsDBNull(index) ? null : getFunc(index);
        }
        throw new ArgumentException("Reader is closed.", "reader");
    }
    
    public static T? GetDataNullableValue<T>(this IDataReader reader, Func<int, T> getFunc, int index) where T : struct
    {
        if (!reader.IsClosed)
        {
            return reader.IsDBNull(index) ? (T?)null : getFunc(index);
        }
        throw new ArgumentException("Reader is closed.", "reader");
    }
