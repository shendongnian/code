    List<Customer> customers = new List<Customer>();
    
    string connectionString = null;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	connection.Open();
    	SqlCommand command = new SqlCommand("GetData");
    	using (IDataReader reader = command.ExecuteReader())
    	{
    		while (reader.Read())
    		{
    			Customer c = new Customer();
    			c.Id = (int)reader["ID"];
    			c.FirstName = (string)reader["FirstName"];
    			c.LastName = (string)reader["LastName"];
    			customers.Add(c);
    		}
    	}
    }
