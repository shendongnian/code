    var results = new List<YourClass>();
    string queryString = "SELECT ...";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        // Call Read before accessing data.
        while (reader.Read())
        {
            
            YourClass obj = new YourClass();
            obj.SomeProperty = reader["SomeProp"]; //SomeProp is field in select statement
            //...
            results.Add(obj);
        }
        reader.Close();
    }
    return results;
