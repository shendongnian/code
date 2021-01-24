    private void UseDbConnection()
    {
    	object[,] arr = GetExcelData();
    
    	using (var db = new EmpContext())
    	{
    
    		db.Database.Initialize(true);
    
    		int count = 0;
    		string sql = "INSERT INTO Venues (Name, City, Telephone) " +
    					 "VALUES (@name, @city, @phone);";
    
    		DbParameter param = null;
    
    		DbConnection conn = db.Database.Connection;
    		conn.Open();
    		DbCommand command = conn.CreateCommand();
    		command.CommandText = sql;
    		command.CommandType = CommandType.Text;
    
    		// Create parameters
    
    		// Name
    		param = command.CreateParameter();
    		param.ParameterName = "@name";
    		command.Parameters.Add(param);
    
    		// City
    		param = command.CreateParameter();
    		param.ParameterName = "@city";
    		command.Parameters.Add(param);
    
    		// Telephone
    		param = command.CreateParameter();
    		param.ParameterName = "@phone";
    		command.Parameters.Add(param);
    
    		// Start from 2-nd row since we need to skip header
    		for (int r = 2; r <= arr.GetUpperBound(0); ++r)
    		{
    			command.Parameters["@name"].Value = (string)arr[r, 1];
    			command.Parameters["@city"].Value = (string)arr[r, 2];
    			command.Parameters["@phone"].Value = (string)arr[r, 3];
    			command.ExecuteNonQuery();
    			++count;
    		}
    
            conn.Close();
    		MessageBox.Show($"{count} records were saved.");
    	}
    }
