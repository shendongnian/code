	string connectionString = "Your Connection string"  
	
	using (SqlConnection con = new SqlConnection(connectionString))
	{
	    //
	    // Open the SqlConnection.
	    //
	    con.Open();
	    //
	    // The following code uses an SqlCommand based on the SqlConnection.
	    //
	    using (SqlCommand command = new SqlCommand("SELECT TOP 2 * FROM Dogs1", con))
	    using (SqlDataReader reader = command.ExecuteReader())
	    {
		while (reader.Read())
		{
		    Console.WriteLine("{0} {1} {2}",
			reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
		}
	    }
	}
