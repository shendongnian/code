    protected static int ExecuteNonQuery(SqlCommand command) =>
        ExecuteCommand(command, cmd => cmd.ExecuteNonQuery());
    protected static string ExecuteScalar(SqlCommand command) =>
        ExecuteCommand(command, cmd => cmd.ExecuteScalar().ToString());
    private static T ExecuteCommand<T>(SqlCommand command, Func<SqlCommand, T> resultRetriever)
    {
        using (SqlConnection connection = new SqlConnection(_connStr))
        {
            command.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(command);
            command.Connection.Open();
            return resultRetriver(command);
        }
    }
