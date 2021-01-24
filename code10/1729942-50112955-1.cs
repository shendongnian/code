    var sqlQuery = @"RAISERROR (N'working', 10,1) WITH NOWAIT";
    
    using (var connection = new SqlConnection(@"Server=localhost\SQLExpress;Database=master;Trusted_Connection=True;"))
    {
    	await connection.OpenAsync();
    
    	connection.InfoMessage += (sender, args) => 
    	{
    		foreach (var element in args.Errors.OfType<SqlError>())
    		{
    			Console.WriteLine($"Class: {element.Class} LineNumber: {element.LineNumber} Message: {element.Message} Number: {element.Number} Procedure: {element.Procedure}");
    		}
    	};
    
    	using (var command = new SqlCommand(sqlQuery, connection))
    	{
    		await command.ExecuteNonQueryAsync();
    	}
    }
