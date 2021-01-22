    SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connection.ConnectionString);
    connectionStringBuilder.ConnectTimeout = 180;
    connection.ConnectionString = connectionStringBuilder.ConnectionString;
    
    connection.Open();
    SqlCommand command = new SqlCommand("sp_ProcedureName", connection);
    command.CommandType = CommandType.StoredProcedure;
    command.CommandTimeout = connection.ConnectionTimeout;
    command.ExecuteNonQuery();
    connection.Close();
