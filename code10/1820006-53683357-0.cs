    int curr = 0;
    foreach (string path in documenteFinal)
    {
    	var fileBytes = File.ReadAllBytes(path);
    
    	connection.Open();
    
    	using (var mySqlCommand = new MySqlCommand("INSERT INTO documents VALUES(null,'" + documenteFinal[curr] + "',@File)", connection))
    	{
    		mySqlCommand.Parameters.Add("@File", MySqlDbType.VarBinary, fileBytes.Length).Value = fileBytes;
    		mySqlCommand.ExecuteNonQuery();
    	}
    
    	connection.Close();
    	
    	curr++;
    }
