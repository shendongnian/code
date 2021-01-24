    var index = 0; // Reset the index
    var idParameterList = new List<string>();
    var dt = new DataTable();
    
    foreach (var familyId in familyIds) {
        var paramName = "@familyId" + index;
        sqlCommand.Parameters.AddWithValue(paramName, familyId);
        idParameterList.Add(paramName);
        index++;
        if (index > 2000) {
            sqlCommand.CommandText = String.Format(query, string.Join(",", idParameterList));
    
            using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                dt.Load(sqlReader);
                
            sqlCommand.Parameters.Clear();
            idParameterList.Clear();
            index = 0;
        }
    }
    if (index > 0) {
        sqlCommand.CommandText = String.Format(query, string.Join(",", idParameterList));
    
        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
            dt.Load(sqlReader);
    }
