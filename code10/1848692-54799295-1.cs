    public List<Item> LoadData()
    {
        var query = "SELECT Column1, Column2, Column3 FROM Table";
        using (var connection = new SqlConnection(connectionString))
        using (var command = connection.CreateCommand())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            
            using (var reader = command.ExecuteReader())
            {
                var data = new List<Item>();
                while(reader.Read())
                {
                    var item = new Item
                    {
                        Column1 = reader.GetString(0),
                        Column1 = reader.GetString(1),
                        Column1 = reader.GetInt32(2)
                    };
                    data.Add(item);
                }
          
                return data;
            }
        }
    }
