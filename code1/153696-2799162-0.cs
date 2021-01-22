    SqlTransaction trans;
    conn.Open(); 
    try 
    {
        trans = conn.BeginTransaction();
        int rows = cmd.ExecuteNonQuery(); 
        trans.Commit();
    }
    catch 
    {
         trans.Rollback();
    }
    conn.Close();
