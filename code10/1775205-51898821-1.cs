     public bool DoesTableContainRows(string tableName, SQLiteConnection connection)
        {
            var command = new SQLiteCommand($"Select * from {tableName } LIMIT 1;", connection);
            var resultReader = command.ExecuteReader();
            // check whether or not a row was returned
            bool containRows = resultReader.Read();
            resultReader.Close();
            return containRows;
        }
