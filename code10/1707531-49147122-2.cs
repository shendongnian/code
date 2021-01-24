    using (SqlConnection sqlConnection = new SqlConnection(connstring))
    {
        using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FOO", sqlConnection))
        {
            sqlCommand.CommandTimeout = 60; //seconds here!
