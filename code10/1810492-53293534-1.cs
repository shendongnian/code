    try
    {
        SqlConnection sqlConn = new SqlConnection("myConnectionString");
        sqlConn.Open();
        ...
    }
    finally
    {
       sqlConn.Close();
    }
