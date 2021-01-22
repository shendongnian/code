    string GetString(DataRow dr, string ColumnName)
    {
        if (dr.IsNull(ColumnName)) 
        {
            return null;
        }
        return (string)dr[ColumnName];
    }
