    private void UseDbConnection()
    {
    	object[,] arr = GetExcelData();
    
    	using (var db = new EmpContext())
    	{
    
    		db.Database.Initialize(true);
    
    		int count = 0;
            // Take a note - use '?' as parameters
    		string sql = "INSERT INTO Venues (Name, City, Telephone) " +
    					 "VALUES (?, ?, ?);";
    
    		DbConnection conn = db.Database.Connection;
    		conn.Open();
    		DbCommand command = conn.CreateCommand();
    		command.CommandText = sql;
    		command.CommandType = CommandType.Text;
    
    		// Create parameters
    		command.Parameters.Add(command.CreateParameter());
    		command.Parameters.Add(command.CreateParameter());
    		command.Parameters.Add(command.CreateParameter());
    
    		for (int r = 2; r <= arr.GetUpperBound(0); ++r)
    		{
                // Access parameters by position
    			command.Parameters[0].Value = (string)arr[r, 1];
    			command.Parameters[1].Value = (string)arr[r, 2];
    			command.Parameters[2].Value = (string)arr[r, 3];
    			command.ExecuteNonQuery();
    			++count;
    		}
    
    		conn.Close();
        	MessageBox.Show($"{count} records were saved.");
    	}
    }
