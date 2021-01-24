    SqlConnection connection = Connect();
    
    SqlCommand command = new SqlCommand();
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = sprocName;
    command.Connection = connection;
    //loop through the dictionary
    foreach (string key in paramList.Keys)
    {
            command.Parameters.AddWithValue(key, paramList[key] == NULL? DBNull.Value, paramList[key]);
    }
    SqlDataReader dataReader = command.ExecuteReader();
