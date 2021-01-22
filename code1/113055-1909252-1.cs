    SqlConnection sqlConnection;
    try
    {
      sqlConnection = new SqlConnection(connectionString);
      // code...
    }
    finally
    {
      if (sqlConnection != null)
         sqlConnection.Dispose();
    }
    
