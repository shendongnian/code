    using (SQLiteConnection c = new SQLiteConnection(DB_CONN_STRING)) {
        c.Open();  //<------ ADD THIS LINE
        string sqlCreateTableAccount = "CREATE TABLE ACCOUNT (ID INTEGER PRIMARY KEY, NAME TEXT NOT NULL);";
        using (SQLiteCommand cmd = new SQLiteCommand(sqlCreateTableAccount, c)) {
            // EXCEPTION THROWN ON NEXT LINE
            cmd.ExecuteNonQuery();
        }
     }
