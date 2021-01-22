    public override int ExecuteNonQuery()
    {
      int records = -1;
      #if !CF
      // give our interceptors a shot at it first
      if ( connection != null && 
           connection.commandInterceptor != null &&
           connection.commandInterceptor.ExecuteNonQuery(CommandText, ref records))
        return records;
      #endif
      // ok, none of our interceptors handled this so we default
      using (MySqlDataReader reader = ExecuteReader())
      {
        reader.Close();
        return reader.RecordsAffected;
      }
    }
