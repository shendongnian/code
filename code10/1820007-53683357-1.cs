    int curr = 0;
    foreach (string path in documenteFinal)
    {
    	var fileBytes = File.ReadAllBytes(path);
    
    	connection.Open();
    
    	using (var command = new MySqlCommand(
    		"INSERT INTO documents VALUES(null,'" + documenteFinal[curr] + "',@File)", connection))
    	{
    		command.Parameters.Add("@File", MySqlDbType.VarBinary, fileBytes.Length).Value = fileBytes;
    		command.ExecuteNonQuery();
    	}
    
    	connection.Close();
    
    	curr++;
    }
