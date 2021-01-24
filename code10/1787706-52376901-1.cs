      using (var sqlCommand = new SqlCommand("Select a,b from table for json path", con))
    {
       try
         {
           using (var reader = sqlCommand.ExecuteReader())
            {
               while (reader.Read())
               {
                 item = new objExample();
                 item.A= reader["a"].ToString();
                 item.B= reader["b"].ToString();
                 item.HasError = false;
                 retVal.Add(item);
                }
               }
    
          }
