    using (var sqlCon = new SqlConnection("Server=127.0.0.1;Database=MyDb;User Id=Me;Password=glop;"))
    {
    	sqlCon.Open();
    	var com = sqlCon.CreateCommand();
    	com.CommandText = "select * from BigTable;select @@ROWCOUNT;";
    	using (var reader = com.ExecuteReader())
    	{
    		while(reader.read()){
    			//iterate code
    		}
    		int totalRow = 0 ;
    		reader.NextResult(); // 
    		if(reader.read()){
    			totalRow = (int)reader[0];
    		}
    	}
    	sqlCon.Close();
    }
