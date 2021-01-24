    public void Select(string query)
    {
    	using (var connection = DBConnect.Initialize())
    	using (var command = new MySqlCommand(connection,query))
    	{
    		
    	}
    }
