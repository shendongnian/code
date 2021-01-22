    public void MyMethod()
    {
        SqlConnection conn;
        try
        {
            conn = new SqlConnection(...);
            // Do stuff
        }
        finally
        {
            conn.Dispose();
        }
    }
