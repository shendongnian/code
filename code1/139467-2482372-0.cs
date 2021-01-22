    public bool DatabaseConnected(string databasePath)
    {
        if (ConnectionOpen())
        {
            using (var command = YourSQLiteConnection.CreateCommand())
            {
                command.CommandText = string.Format(DATABASE_QUERY);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (string.Compare(reader[FILE_NAME_COL_HEADER].ToString(), databasePath, true) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
