    try
    {
        SqlConnection cn = new SqlConnection());
        SqlTransaction tr = cn.BeginTransaction());
    
        //some code
        tr.Commit();
    }
    finally
    {
        cn.Dispose();
        tr.Dispose();
    }
