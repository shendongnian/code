	private void update()
	{
		 using(OracleConnection con = new OracleConnection("Connection Statement"))
		 {
			 con.Open();
			 using(var command = new OracleCommand("Select Statement", con))
			 using(OracleDataReader reader = command.ExecuteReader()}
			 {
				
			 }
			 // A for loop
			 using(var command = new OracleCommand("Update statement", con))
			 {
			   command.ExecuteNonQuery();
			 }
			 using(var command = new OracleCommand("Second Update statement", con))
			 {
			   command.ExecuteNonQuery();
			 }
		 }
	}
