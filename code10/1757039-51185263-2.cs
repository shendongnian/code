    try
    {
        string sqlStr = "Select armnumber from assign where  id=@id";
        MySqlConnection connection = new MySqlConnection(myConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Parameters.AddWithValue("@id", 1);
        cmd.CommandType = CommandType.Text;                
        cmd.CommandText = sqlStr;
        cmd.Connection = connection;
        connection.Open();
        var result = cmd.ExecuteScalar();
        int armnumber = result != null ? int.Parse(result.ToString()) : 0;
        if (counter == armnumber)
        {
            // code here
        }
    }
    
    catch (MySqlException ex)
    {
    }
