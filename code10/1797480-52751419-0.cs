    // using DBNull.Value comparison
    public static T GetValue<T>(this SqlDataReader reader, string columnName)
    {
        var value = reader[columnName]; // read column value
        
        return value == DBNull.Value ? default(T) : (T)value;
    }
    // alternative using GetOrdinal and IsDBNull
    public static T GetValue<T>(this SqlDataReader reader, string columnName) 
    {
        int index = reader.GetOrdinal(columnName); // read column index
        return reader.IsDBNull(index) ? default(T) : (T)reader.GetValue(index);
    }
