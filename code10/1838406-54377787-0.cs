    public List<IDictionary<string, string>> Get(string query)
    {
    	var list = new List<IDictionary<string, string>>();
        if (this.OpenConnection())
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
    
            while (reader.Read())
            {
    			var querybuilder = new Dictionary<string, string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    
                    querybuilder.Add(reader.GetName(i), reader.GetString(i));
                }
    			list.Add(querybuilder);
            }
    
            reader.Close();
            this.CloseConnection();
        }
    
        return list;
    }
