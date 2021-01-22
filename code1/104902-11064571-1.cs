    ...            
    MySqlConnection conn = new MySqlConnection(connString);
    MySqlCommand command = conn.CreateCommand();
    command.CommandText = "SELECT COUNT(*) FROM studentTable";
    try
    {
    	conn.Open();
    }
    catch (Exception ex)
    {
    	label1.Content = ex.Message;
    }
    
    reader = command.ExecuteReader();
    while (reader.Read())
    {
    	label1.Content = "";
    	label1.Content = reader.GetString(0);
    }
    
    reader.Close();
    conn.Close();
