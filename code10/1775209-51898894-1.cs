        int count;
        using (SQLiteConnection db = new SQLiteConnection("MY_CXN_STRING"))
        using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM SystemSettings"))
        {
            db.Open();
            count = (int)cmd.ExecuteScalar();
            db.Close();
        }
    bool hasRows = count != 0;
