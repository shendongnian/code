    string inputFile = "{filepath to your input file}";
    using (var conn = new SqlConnection())
    {
    	conn.ConnectionString = "{your connection string}";
    	conn.Open();
    	File.ReadAllLines(inputFile)
    		.SelectMany(l => l.Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries))
    		.Select(l => $"INSERT INTO Fares  Values ('{l}')")
    		.ToList()
    		.ForEach(c =>
    		{
    			using (var cmd = new SqlCommand(c, conn))
    			{
    				cmd.ExecuteNonQuery();
    			}
    		});
    }
