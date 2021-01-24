    using (var conn = new SqlConnection(connStr))
    {
        conn.Open();
        var cmd = new SqlCommand(sql , conn, conn.BeginTransaction());
    
        try
        {
            cmd.ExecuteNonQuery();
            cmd.Transaction.Commit();
        }
        catch(System.Exception ex)
        {
            cmd.Transaction.Rollback();
            throw ex;
        }
    
        conn.Close();
    }
