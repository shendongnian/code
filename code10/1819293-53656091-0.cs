    public string getkampioen(string selecteditem)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = ("select * FROM clubs where naam = '" + selecteditem + "'");
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader Reader = cmd.ExecuteReader();
            string kampioen = "";
            while (Reader.Read())
            {
               kampioen = (string)Reader["aantalkampioenschappen"].ToString();
            }
            return kampioen; 
        }
    }
