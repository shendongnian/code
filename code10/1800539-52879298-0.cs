    using (SQLiteConnection sql_con = new SQLiteConnection("Data Source=test.db3;Version=3;New=false;Compress=true;"))
    {
        sql_con.Open();
        using (SQLiteCommand sql_cmd = sql_con.CreateCommand())
        {
            sql_cmd.CommandText = "delete from table1";
            sql_cmd.ExecuteNonQuery();
        }
    }
