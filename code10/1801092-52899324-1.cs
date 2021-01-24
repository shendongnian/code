    using (var connection = new SqlConnection("Connection"))
    using (var command = new SqlCommand("Retrieve", connection))
    {
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Action", "Retrieve");
        command.Parameters.AddWithValue("@name", this.customer_Name);
        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var item = new YourClass();
                // You can use GetX() methods to get the value of the fields
                item.Name = reader.GetString("name");
                // You can also access the fields by using bracket notation
                item.Age = (int)reader["age"];
                
                // Be careful of nullable fields though!
            }
        }
    }
