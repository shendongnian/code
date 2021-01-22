    SQLiteConnection connection = new SQLiteConnection("Data source=PATH_TO_YOUR_DB;Version=3");
    connection.Open();
    SQLiteCommand command = connection.CreateCommand();
    command.CommandText = "insert into something values (1,2,3)";
    command.ExecuteNonQuery();
    connection.Close();
