    SQLiteConnection connection = new SQLiteConnection(sqliteConnString);
    connection.Open();
    
    DataRow[] result = connection.GetSchema("Tables").Select("Table_Name = 'MyTable'");
    if (result == null || result.Length == 0)
    {                  
        SQLiteCommand cmd = new SQLiteCommand(
                            "CREATE TABLE MyTable (Id int NOT NULL, OtherTable_Id nchar(40) REFERENCES OtherTable (Id) On Delete CASCADE On Update NO ACTION, SomeData nvarchar(1024) NOT NULL, Primary Key(Id) );"
        , connection);
    
        cmd.ExecuteNonQuery();
    }
    
    connection.Close();
