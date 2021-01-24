    use (var connection ...)
    {
      connection.Open();
      foreach (var sqlBatch in ...)
      {
        use (var command = new Command(..., connection))
        {
          command.CommandText = sqlBatch;
          ...
          command.ExecuteNonQuery();
        }
      }
    }
