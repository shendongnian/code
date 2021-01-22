    SqlConnection cn = new SqlConnection(Global.sDSN)
    try
    {
    ....
    }
    finally
    {
        cn.Dispose();
    }
