    string script = File.ReadAllText(@"E:\someSqlScript.sql");
    
    // split script on GO command
    IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
    
    Connection.Open();
    foreach (string commandString in commandStrings)
    {
        if (!string.IsNullOrWhiteSpace(commandString.Trim()))
    	{
    		using(var command = new SqlCommand(commandString, Connection))
    		{
    			command.ExecuteNonQuery();
    		}
    	}
    }     
    Connection.Close();
