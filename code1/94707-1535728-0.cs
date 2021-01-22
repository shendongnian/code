    SqlConnection connection = new SqlConnection(connectionString);
    SqlCommand command = new SqlCommand("CREATE DATABASE database_name", connection);
    command.Connection.Open();
    command.ExecuteReader();
    connection.Close();
