     public static T GetColumnValue<T>(string columnName, DataRow dr)
     {
        Type typeParameterType = typeof(T);
    
        return dr[columnName] != DBNull.Value
                    ? (T) Convert.ChangeType(dr[columnName] , typeParameterType)
                    : default(T);
     }
