    static void SqlQuery(string cmdString)
    {
        using (connection = new SqlConnection(connString))
        { 
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = cmdString;
            cmd.ExecuteNonQuery();
        }
    }
