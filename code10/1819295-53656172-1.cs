    public string getkampioen(string selecteditem)
    {
        string kampioen = string.empty; // declared outside of the while 
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = ("select * FROM clubs where naam = '" + selecteditem + "' limit one");
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
               kampioen = (string)Reader["aantalkampioenschappen"].ToString();
            }
            return kampioen; 
        }
    }
