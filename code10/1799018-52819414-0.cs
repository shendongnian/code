    using (var sqlConnection =new SqlConnection(connectionString)){
       var cmd = new SqlCommand(query, sqlConnection);
       sqlConnection.Open();
       var reader = cmd.ExecuteReader();
       while(reader.Read())
        {
             //do whatever you want
        };
    }
