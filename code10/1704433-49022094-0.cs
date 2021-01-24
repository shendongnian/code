    static void SqlQuery(string cmdString)
    {
        using (connection = new SqlConnection(connString))
        { 
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = cmdString;
            cmd.ExecuteNonQuery();
        }
    }
