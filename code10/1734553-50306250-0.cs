    void Insert()
    {
        string query = @"
		INSERT INTO [dbo].[table_battery]
           ([capacity], [description], [image], [price]) 
        VALUES 
           (@capacity, @description, @fileContent, @price)";
		
        // setup values you want to use for the query
		int capacity = ... ;
		string descr = ... ;
		float price = ...;
		
        string path = ... // you can use relative or absolute path here
        byte[] fileContent = File.ReadAllBytes(path);
		SqlConnection conn = null;// get connection some how;
		using (conn)
		{
			using (SqlCommand command = new SqlCommand(query, conn))
			{
				command.Parameters.Add("@capacity", SqlDbType.Int).Value = capacity;
				command.Parameters.Add("@description", SqlDbType.NVarChar).Value = descr;
				command.Parameters.Add("@fileContent", SqlDbType.VarBinary).Value = fileContent;
				command.Parameters.Add("@price", SqlDbType.Float).Value = price;
				
				command.ExecuteNonQuery();
			}
		}
    }
