    using (SqlTransaction tn = conn.BeginTransaction())
    {
        cmd1 = new SqlCommand("...", conn, trn);
        cmd1.ExecuteNonQuery();
        cmd2 = new SqlCommand("...", conn, trn);
        cmd2.ExecuteNonQuery();
        ...
        trn.Commit();
    }
