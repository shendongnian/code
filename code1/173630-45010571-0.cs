    /// <summary>
    /// Checks if the given table contains a column with the given name.
    /// </summary>
    /// <param name="tableName">The table in this database to check.</param>
    /// <param name="columnName">The column in the given table to look for.</param>
    /// <param name="connection">The SQLiteConnection for this database.</param>
    /// <returns>True if the given table contains a column with the given name.</returns>
    public static bool ColumnExists(string tableName, string columnName, SQLiteConnection connection)
    {
        var cmd = new SQLiteCommand("PRAGMA table_info(" + tableName + ")", connection);
        var dr = cmd.ExecuteReader();
        while (dr.Read())//loop through the various columns and their info
        {
            var value = dr.GetValue(1);//column 1 from the result contains the column names
            if (columnName.Equals(value))
            {
                dr.Close();
                return true;
            }
        }
        dr.Close();
        return false;
    }
