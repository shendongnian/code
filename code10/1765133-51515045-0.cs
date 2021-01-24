      using (var connection = new SqlConnection(cb.ConnectionString)) {
        try {
          connection.Open();
          // connection.Open() either succeeds (and so we print the message) 
          // or throw an exception; no need to check 
          Console.WriteLine("Connected!");
          //TODO: edit the SQL if required
          string sql =
            @"select IsActivated
                from MyTable";
          using (var query = new SqlCommand(sql, connection)) {
            using (var reader = query.ExecuteReader()) {
              while (reader.Read()) {
                // Now it's time to answer your question: let's read the value 
                //   reader["IsActivated"] - value of IsActivated as an Object
                //   Convert.ToBoolean     - let .Net do all low level work for you
                bool isActivated = Convert.ToBoolean(reader["IsActivated"]);
                // Uncomment, if you insist on 0, 1
                // int bit = Convert.ToInt32(reader["IsActivated"]);
                //TODO: field has been read into isActivated; put relevant code here  
              }
            }
          }
        }
        catch (DataException e) { // Be specific: we know how to process data errors only
          Console.WriteLine(e);
          throw;
        }
      }
