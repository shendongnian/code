	public static void Test()
	{
	    GetRs("SELECT Col FROM TABLE", reader =>
	    {
	        while(reader.Read())
	        {
	            // do stuff with data here e.g. var value = reader[0];
	        }
	    });
	}
