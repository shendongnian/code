    public DbConnection CreateConnectionForSchemaCreation(string fileName)
    {
        var conn = new SQLiteConnection();
        conn.ConnectionString = new DbConnectionStringBuilder()
        {
            {"Data Source", fileName},
            {"Version", "3"},
            {"FailIfMissing", "False"},
        }.ConnectionString;
        conn.Open();
        return conn;
    }
