    private SQLiteCommand command;
    private SQLiteConnection connection;
    
    connection = new SQLiteConnection(Config.Database.ConnectionString.ToString());
    connection.Open();
    
    command = connection.CreateCommand();
    
    SQLiteConnection.CreateFile(Config.Database.Path);
    
    command.CommandText = Config.Database.CreateCommandText;
    
    command.ExecuteNonQuery();
