    SqlCommand command = new SqlCommand();
    command.Connection = openConnection();
    using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
    {
        while (dataReader.Read())
        {
            // Do stuff with results
        }
    }
