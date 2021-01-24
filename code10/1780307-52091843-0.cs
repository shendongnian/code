    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
       String query = "SELECT * FROM dbo.apartments";
       using (SqlCommand command = new SqlCommand(query, connection))
       {
           connection.Open();
           MyObject myObject= new MyObject();
           var reader = command.ExecuteReader();
           if (reader.HasRows)
           {
              while (reader.Read())
              {
                   myObject.Name = reader["Name"].ToString();
              }
           }
          var JsonResult = JsonConvert.SerializeObject(myObject);
        } 
    }
