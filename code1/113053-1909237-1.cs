    {
      SqlConnection sqlConnection = new SqlConnection(connectionString);
      try
      {
        // .. code
      }
      finally
      {
        if (sqlConnection!= null)
          ((IDisposable)sqlConnection).Dispose();
      }
    }
