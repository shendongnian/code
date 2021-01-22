    using (SqlConnection connection = new SqlConnection(connectionstring)) {
       connection.Open();
    
       string sql = "CREATE TABLE #foo (myvalue [INT]) ";
       using (SqlCommand command = connection.CreateCommand()) {
          command.CommandText = sql;
          command.CommandType = CommandType.Text;
    
          command.ExecuteNonQuery(); // create the temp table
    
          foreach (int value in myValuesList) {
             command.CommandText = "INSERT INTO #foo ([myvalue]) VALUES (" + value + ") ";
    
             command.ExecuteNonQuery();
          }
    
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "StoredProcThatUsesFoo";
          
          // fill in any other parameters
    
          command.ExecuteNonQuery();
       }
    }
