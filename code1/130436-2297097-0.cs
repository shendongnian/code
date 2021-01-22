    public static TResult Execute<TResult>(SqlConnection connection, string cmdText)
    {
        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        {
            return (TResult)cmd.ExecuteScalar();
        }
    }
