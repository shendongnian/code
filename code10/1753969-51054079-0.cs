    using (SqlConnection conn = new SqlConnection("Connection String"))
    {
        conn.Open();
        SqlTransaction trans;
        trans = conn.BeginTransaction();
        string selectQuery = "your sql query";
        SqlCommand command = new SqlCommand(selectQuery, connection);
        int iResult = command.ExecuteNonQuery();
        if (iResult > 0)
        {
            trans.Commit();
        }else{
            trans.Rollback();
        }
        conn.Close();
    }
