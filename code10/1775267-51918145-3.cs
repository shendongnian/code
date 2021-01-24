    private void UseExecuteSqlCommand()
    {
    	object[,] arr = GetExcelData();
    
    	using (var db = new EmpContext())
    	{
    
    		db.Database.Initialize(true);
    
    		int count = 0;
    		string sql = "INSERT INTO Venues (Name, City, Telephone) " +
                         "VALUES (@name, @city, @phone);";
    
    		// Start from 2-nd row since we need to skip header
    		for (int r = 2; r <= arr.GetUpperBound(0); ++r)
    		{
    			db.Database.ExecuteSqlCommand(
    				sql,
    				new SqlCeParameter("@name", (string)arr[r, 1]),
    				new SqlCeParameter("@city", (string)arr[r, 2]),
    				new SqlCeParameter("@phone", (string)arr[r, 3])
    			);
    
    			++count;
    		}
            conn.Close();
            MessageBox.Show($"{count} records were saved.");
    	}
    }
