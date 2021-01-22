    public void InsertData(QuoteDataSet dataSet, String tableName)
    {
        int numRowsUpdated = 0;
        using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
        {
            conn.Open();
            using (SQLiteTransaction transaction = conn.BeginTransaction())
            using (SQLiteDataAdapter sqliteAdapter = new SQLiteDataAdapter("SELECT * FROM " + tableName, conn))
            {
                using (sqliteAdapter.InsertCommand = new SQLiteCommandBuilder(sqliteAdapter).GetInsertCommand())
                {
                    var rows = dataSet.Tags.AsEnumerable();
                    foreach (var row in rows)
                    {
                        row.SetAdded();
                    }
                    numRowsUpdated = sqliteAdapter.Update(dataSet, tableName);
                }
                transaction.Commit();
            }
        }
        Console.WriteLine("Num rows updated is " + numRowsUpdated);
    }
