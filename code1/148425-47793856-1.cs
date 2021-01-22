    try
    {
        SqlCeConnection conn = new SqlCeConnection(ConnectionString);
    
        conn.Open();
    
        using (SqlCeCommand cmd =
            new SqlCeCommand("SELECT stuff FROM SomeTable", conn))
        {
          // do some stuff
        }
    }
    catch (Exception ex)
    {
        
    }
    finally
    {
    \\close connection here
    }
