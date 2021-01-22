    Database db = DatabaseFactory.CreateDatabase();
    
    using (IDataReader reader = db.ExecuteReader(CommandType.Text, "SQL here..." ))
    {
       while (reader.Read())
        {
            action(reader);
        }
    }
