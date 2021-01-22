    public SQLiteDataAdapter(string commandText, SQLiteConnection connection)
    {
        this.SelectCommand = new SQLiteCommand(commandText, connection);
    }
 
 
