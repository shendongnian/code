    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        // Create the command and set its properties.
        SqlCommand command = new SqlCommand();
        SqlCommand command = new SqlCommand 
           ("Proc_name", connection); 
        command.CommandType = CommandType.StoredProcedure;
        // Add the input parameters and set the properties.
        SqlParameter parameter1 = new SqlParameter();
        parameter.ParameterName = "@Param1";
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = param1;
        SqlParameter parameter2 = new SqlParameter();
        parameter.ParameterName = "@Param2";
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = param2;
        // Same for params 3 and 4...
        // Add the parameter to the Parameters collection. 
        command.Parameters.Add(parameter1);
        command.Parameters.Add(parameter2);
        command.Parameters.Add(parameter3);
        command.Parameters.Add(parameter4);
        // Open the connection and execute the reader.
        connection.Open();
        SqlDataReader reader = command.ExecuteNonQuery();
        reader.Close();
    }
