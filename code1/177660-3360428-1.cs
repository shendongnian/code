    using (var connection = new SqlConnection(connectionStringForServerA)
    {
      connection.Open();
      var query = "SELECT SerialNumber, PartNumber FROM [dbo].[TableA] WHERE SerialNumber = '1'";
      using (var adapter = new SqlDataAdapter(query, connection);
      {
        var data = new DataTable();
        adapter.Fill(data);
    
        using (var connectionB = new SqlConnection(connectionStringForServerB)
        {
           var query = "INSERT INTO [dbo].[TableA] (SerialNumber, PartNumber) VALUES (@Serial, @Part)";
           foreach(DataRow recordFromServerA in data.Rows)
           {
             using(var command = new SqlCommand(query, connectionB)
             {
               command.Parameters.AddWithValue("@Serial", recordFromServerA["SerialNumber"]);
               command.Parameters.AddWithValue("@Part", recordFromServerA["PartNumber"]);
               
               command.ExecuteNonQuery();
             }
           }
        }
      }
    }
