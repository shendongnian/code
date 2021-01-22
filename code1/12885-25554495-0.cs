    public static bool GetValueOrDefault<T>(this SqlDataReader rdr, string columnName, out T Result)
    {
        try
        {
            object columnValue = reader[columnName];
            
            Result = (columnValue!=null && columnValue != DBNull.Value) ? (T)columnValue : default(T);
            
            return columnValue!=null && columnValue != DBNull.Value;
        }
        catch
        {
            // Possibly an invalid cast?
            return false;
        }
    }
