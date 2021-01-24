    public void SaveDatabase()
    {
        using (var conn = new SQLiteConnection(dbConnectionString))
        {
            using (var adapter = new SQLiteDataAdapter("SELECT * FROM proxies", conn))
            {
                using (var builder = new SQLiteCommandBuilder(adapter))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("DELETE FROM proxies", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    adapter.InsertCommand = builder.GetInsertCommand();
                    adapter.DeleteCommand = builder.GetDeleteCommand();
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    var table = proxies.ToDataTable();
                    adapter.Update(table);
    
                }
            }
        }
    }
