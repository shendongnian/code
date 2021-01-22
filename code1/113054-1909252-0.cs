    SqlConnection sqlConnection;
    try
    {
      sqlConnection = new SqlConnection(connectionString);
      // code...
    }
    finally
    {
      sqlConnection.Dispose();
    }
    
