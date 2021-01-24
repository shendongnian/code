    int count;
    using (SQLiteConnection db = new SQLiteConnection("MY_CXN_STRING"))
    using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM MY_TABLE"))
    {
        db.Open();
        count = (int)cmd.ExecuteScalar();
        db.Close();
    }
