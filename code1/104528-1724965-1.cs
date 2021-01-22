    SqlConnection connection;
    try 
    {
        connection = new SqlConnection();
        connection.Open();
    }
    catch(Exception ex)
    {
        // handle
    }
    finally 
    {
        if (connection != null)
        {
            connection.Dispose();
        }
    }
