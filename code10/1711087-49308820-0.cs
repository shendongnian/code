    protected static T ExecuteScalar<T>(SqlCommand command)
    {
        using (SqlConnection connection = new SqlConnection(_connStr))
        {
            command.Connection = connection;
            //SqlDataAdapter da = new SqlDataAdapter(command); //not needed...
            command.Connection.Open();
            return (T)command.ExecuteScalar();
        }
    }
