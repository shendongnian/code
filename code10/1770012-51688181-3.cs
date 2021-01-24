    private static void OpenSqlConnection(string connString)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
            Console.WriteLine("State: {0}", connection.State);
        }
    }
