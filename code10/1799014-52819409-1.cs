      // If you don't want to hardcode connection's type - SqlConnection -
      // (possible purpose of DatabaseUtil class) use dependency injection
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();
        // sqlConnection.CreateCommand() - we can avoid dependency 
        // and don't hardcode SqlCommand as "new SqlCommand"
        //DONE: wrap IDisposable into using, do not close it explicitly
        using (var cmd = sqlConnection.CreateCommand()) {
          cmd.CommandText = query;
          //TODO: you may want to provide Parameters here
          //DONE: wrap IDisposable into using, do not close it explicitly
          using (var reader = cmd.ExecuteReader()) {
            // reader.Read() returns true if records is read 
            // (i.e. we have at least one record)
            if (reader.Read()) {
              // We have at least one row
              // some code here
            } 
          }  
        } 
      }
