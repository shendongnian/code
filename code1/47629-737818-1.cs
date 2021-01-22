    // safe int32 assignment (using column name)
    public static int GetInt32Safe(this SqlDataReader dr, string column)
    { 
        object value = dr[column];
        if (value != DBNull.Value)
        {
            return (int)value;
        }
        else
        {
            return 0;
        }
    }
    // safe int32 assignment (using column index)
    public static int GetInt32Safe(this SqlDataReader dr, int colno)
    { 
        if (!dr.IsDBNull(colno))
        {
            return dr.GetInt32(colno);
        }
        else
        {
            return 0;
        }
    }
    
   
