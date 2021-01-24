    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
       String query = "SELECT * FROM dbo.apartments";
       using (SqlCommand command = new SqlCommand(query, connection))
       {
           connection.Open();
           List<MyObject> myObjectList= new List<MyObject>();
           var reader = command.ExecuteReader();
           if (reader.HasRows)
           {
              while (reader.Read())
              {    MyObject myObject = new MyObject();
                   myObject.Name = reader["Name"].ToString();
                   myObjectList.Add(myObject);
              }
           }
          var JsonResult = JsonConvert.SerializeObject(myObjectList);
        } 
    }
