    //keyList is a List<string>
    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
    string sql = "SELECT fieldList FROM dbo.tableName WHERE keyField in (";
    int i = 1;
    foreach (string key in keyList) {
        sql = sql + "@key" + i + ",";
        command.Parameters.AddWithValue("@key" + i, key);
        i++;
    }
    sql = sql.TrimEnd(',') + ")";
