    using(SqlConnection conn = new SqlConnection(connString))
    {
      //use connection
    }
    
    //shorter than
    
    SqlConnection conn = new SqlConnection(connString)
    try
    {
      //use connection 
    }
    finally
    {
        conn.Dispose();
    }
