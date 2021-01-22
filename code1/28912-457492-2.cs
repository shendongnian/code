        private void LoanSchema()
        {
             private List<String> tablesList = new List<String>();
             private Dictionary<String, String> columnsDictionary = new Dictionary<String, String>();
              
              string connectionString = "Integrated Security=SSPI;" +
              "Persist Security Info = False;Initial Catalog=Northwind;" +
              "Data Source = localhost";
              SqlConnection connection = new SqlConnection();
              connection.ConnectionString = connectionString;
              connection.Open();
             
              SqlCommand command = new SqlCommand();
              command.Connection = connection;
              command.CommandText = "exec sp_tables";
              command.CommandType = CommandType.Text;
    
              SqlDataReader reader = command.ExecuteReader();
            
               if (reader.HasRows)
               {
                   while (reader.Read())
                      tablesList.Add(reader["TABLE_NAME"].ToString());
               }
               reader.Close();
    
               command.CommandText = "exec sp_columns @table_name = '" +
               tablesList[0] + "'";
               command.CommandType = CommandType.Text;
               reader = command.ExecuteReader();
    
                if (reader.HasRows)
                {
                    while (reader.Read())
                              columnsDictionary.Add(reader["COLUMN_NAME"].ToString(), reader["TYPE_NAME"].ToString());
                 }
    }
    
    
