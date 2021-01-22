    SQLiteConnection mDBcon = new SQLiteConnection();
    mDBcon.ConnectionString = "Data Source=" + DataSourcePath;
    mDBcon.Open();
    SQLiteCommand cmd = new SQLiteCommand(mDBcon);
    cmd.CommandText = "CREATE TABLE IF NOT EXISTS tags (ISBN VARCHAR(15), Tag VARCHAR(15));";
    cmd.ExecuteNonQuery();
