     public static T GetColumnValue<T>(string columnName, DataRow dr)
     {
        Type typeParameterType = typeof(T);
    
        //dr.Table.Columns.Contains(columnName)
        //this line can be removed if you are sure you are going to get columns 
        //it all depends on requirement and preference
        return dr.Table.Columns.Contains(columnName) && dr[columnName] != DBNull.Value
                    ? (T) Convert.ChangeType(dr[columnName] , typeParameterType)
                    : default(T);
     }
