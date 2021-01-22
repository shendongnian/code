    SQLiteConnection sql_con = new SQLiteConnection("data source=YOUR DATA SOURCE");
    sql_con.Open();
    SQLiteCommand sql_cmd = sql_con.CreateCommand();
    sql_cmd.CommandText = "SELECT * FROM table_name";
    SQLiteDataAdapter DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
    DataSet DS = new DataSet();
    DB.Fill(DS);
    YourListView.DataContext = DS.Tables[0].DefaultView;
