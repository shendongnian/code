    StringBuilder sql = new StringBuilder();
    int batchSize = 10;
    int currentBatchCount = 0;
    SqlCommand cmd = null; // The SqlCommand object to use for executing the sql.
    for(int i = 0; i < numberOfUpdatesToMake; i++)
    {
      int sid = 0; // Set the s_id here
      int id = 0; // Set id here
      sql.AppendFormat("update mytable set s_id = {0} where id = {1}; ", sid, id);
      
      currentBatchCount++;
      if (currentBatchCount >= batchSize)
      {
        cmd.CommandText = sql.ToString();
        cmd.ExecuteNonQuery();
        sql = new StringBuilder();
        currentBatchCount = 0;
      }
    }
