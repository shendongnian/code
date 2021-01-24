    var sandboxConnection = new SqliteConnection("Data Source=:memory:");
    sandboxConnection.Open();
    using (var physicalConnection = new SqliteConnection("Filename=physical.db"))
    {
        physicalConnection.Open();
        physicalConnection.BackupDatabase(sandboxConnection);
    }
    optionsBuilder.UseSqlite(sandboxConnection);
