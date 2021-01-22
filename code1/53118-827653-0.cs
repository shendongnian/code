    using (SQLiteConnection sqlite_conn = new SQLiteConnection(connectionString))
    using (SQLiteCommand sqlite_cmd = new SQLiteCommand())
    {
        sqlite_conn.Open();
        sqlite_cmd.Connection = sqlite_conn;
        sqlite_cmd.CommandText = "INSERT INTO SOMETHING SOMETHING;";
        sqlite_cmd.ExecuteNonQuery();
    } // no need to call .Close(): IDisposable normally handles it for you
