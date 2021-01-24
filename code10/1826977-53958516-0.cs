    public static T GetSafeValue<T>(this DbDataReader reader, int index)
    {
        if (reader.IsDBNull(index))
            return default(T);
        return (T)reader.GetValue(index);
    }
    public static T GetSafeValue<T>(this DbDataReader reader, string name) 
    {
        var col = reader.GetOrdinal(name);
        
        if ( reader.IsDBNull(col) )
            return default(T);
                
        return (T)reader.GetValue(col);
    }
