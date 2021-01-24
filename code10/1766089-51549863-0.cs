    string assign = DateTime.Now;
    string myConnectionString;
        myConnectionString= "server=localhost;uid=root;pwd=root;database=medicloud;SslMode=None;charset=utf8";
    string select = "Select time from assign where userId=@name";
    using (MySqlConnection con = new MySqlConnection(myConnectionString))
    {
        using (MySqlCommand cmd = new MySqlCommand(select))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            
            cmd.Parameters.AddWithValue("@name", txtValue.Text);                      
        
            MySqlDataReader cursor = cmd.ExecuteReader();
            while (cursor.Read())
            {
                assign = cursor["time"];
            }
        }
        string insert = "INSERT into bluetooth (userId,arm,armNumberDone,armNumber,comDate,assignDate,status) VALUES (@name, @stupid0, @stupid1, @stupid2, @stupid3, @stupid4, @stupid5)";
            
        using (MySqlCommand cmd = new MySqlCommand(insert))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@stupid0", databaseLine);
            cmd.Parameters.AddWithValue("@stupid1", counter);
            cmd.Parameters.AddWithValue("@stupid2", databaseValue);
            cmd.Parameters.AddWithValue("@stupid3", DateTime.Now);
            cmd.Parameters.AddWithValue("@stupid4", assign);
            cmd.Parameters.AddWithValue("@stupid5", complete);
            cmd.ExecuteNonQuery();
        }
    }
