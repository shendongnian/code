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
   
