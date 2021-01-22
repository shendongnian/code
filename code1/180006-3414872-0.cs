    var setDate = DateTime.Now();
    
    using (SqlCommand command = new SqlCommand("SELECT * FROM TableX WHERE SetDate > @SetDate", connection))
    {
    	// Add new SqlParameter to the command.
    	command.Parameters.Add(new SqlParameter("@SetDate", SqlDbType.DateTime, setDate));
    	// Read in the SELECT results.
    	SqlDataReader reader = command.ExecuteReader();
    	//More code
    }
