    public bool DoesTableContainRows(string tableName, SqliteConnection connection)
    {
        using (var command = new SqliteCommand($"Select * from {tableName } LIMIT 1;", connection))
        {
            using (var resultReader = command.ExecuteReader())
            {
                 // check whether or not a row was returned
                 bool containRows = resultReader.Read();
                 resultReader.Close();
                 return containRows;
            }
        }
    }
