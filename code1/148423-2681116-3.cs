    try
    {
        conn = new SqlCeConnection(ConnectionString);
        conn.Open();
    
        SqlCeCommand cmd = conn.CreateCommand();
        cmd.CommandText = "...";
    
        cmd.ExecuteNonQuery();
    }
    finally
    {
        conn.Close();
    }
