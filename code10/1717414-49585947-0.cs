    public List<Item> FillData()
    {
        List<Item> myItems = new List<Item>();
        using (var cmd = new OdbcCommand("SELECT Name FROM Items", new OdbcConnection()))
        {
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var i = new Item();
                        i.Name = reader.GetString(0);
                        // or   i.Name = Convert.ToString(reader["Name"])  
                        // or   i.Name = reader["Name"].ToString() 
                        // or  create a Item-Constructor  ... or ....
                        // read all the other attributes into this item
                        // add item to collection to "remember" it
                        myItems.Add(i);
                    }
                }
            }
        }
        return myItems; // or use a class member to store all your items
    }
