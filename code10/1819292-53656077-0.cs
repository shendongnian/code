    public string getkampioen(string selecteditem)
    {
        string kampioen; //declare here
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = ("select * FROM clubs where naam = '" + selecteditem + "'");
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
               kampioen = (string)Reader["aantalkampioenschappen"].ToString();
            }
            return kampioen; 
        }
    }
