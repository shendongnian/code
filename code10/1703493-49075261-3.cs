    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // TODO: Dispose with DbContext
        _connection = new SqliteConnection(_connectionString);
        _connection.Open();
        // TODO: Avoid SQL injection (see post)
        var command = _connection.CreateCommand();
        command.CommandText = "PRAGMA key = '" + _password + "'";
        command.ExecuteNonQuery();
        
        options.UseSqlite(_connection);
    }
