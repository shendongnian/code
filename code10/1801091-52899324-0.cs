    using (var connection = new SqlConnection("Connection"))
    using (var command = new SqlCommand("Retrieve", connection))
    {
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Action", "Retrieve");
        command.Parameters.AddWithValue("@name", this.customer_Name);
        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            while(reader.Read())
            {
                var item = new YourClass();
                item.Property = reader.GetString("name");
            }
        }
    }
