    SQLiteConnection = new SQLiteConnection(cntnStr);
    connection.Open();
    string query = "Insert Into Pages (ID, Data, Name) Values (?, ?, ?)";
    using (SQLiteCommand command = new SQLiteCommand(query, connection)
    {
        command.Parameters.Add("id", DbType.Int32);
        command.Parameters.Add("data", DbType.String);
        command.Parameters.Add("name", DbType.String);
        foreach(Page p in pages)
        {
             command.Parameters["id"].Value = p.Id;
             command.Parameters["data"].Value = p.Data;
             command.Parameters["name"].Value = p.Name;
             command.ExecuteNonQuery();
        }
    }
