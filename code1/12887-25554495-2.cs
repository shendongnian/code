    public static bool GetValueOrDefault<T>(this SqlDataReader Reader, string ColumnName, out T Result)
    {
        try
        {
            object ColumnValue = Reader[ColumnName];
            
            Result = (ColumnValue!=null && ColumnValue != DBNull.Value) ? (T)ColumnValue : default(T);
            
            return ColumnValue!=null && ColumnValue != DBNull.Value;
        }
        catch
        {
            // Possibly an invalid cast?
            return false;
        }
    }
