    List<int> intList = new List<int> {1,2,3,4,5};
    string cmdText = "SELECT COLUMN, COLUMN2 from TABLE where COLUMN in({0})";
    List<SQLiteParameter> prms = new List<SQLiteParameter>();
    List<string> placeholders = new List<string>();
    int x = 1;
    foreach (int n in intList)
    {
        prms.Add(new SQLiteParameter {ParameterName = "@p" + x, DbType = DbType.Int32, Value = n});
        placeholders.Add("@p" + x);
        x++;
    }
    cmdText = string.Format(cmdText, string.Join(",", placeholders));
    
    // At this point your command text looks like
    // SELECT COLUMN, COLUMN2 from TABLE where COLUMN in(@p1,@p2,@p3,@p4,@p5)
    
    using(SQLiteConnection con = new SQLiteConnection("Data Source=|DataDirectory|\\mydb.db"))
    using(SQLiteCommand g = new SQLiteCommand(cmdText, con))
    {
        con.Open();
        g.Parameters.AddRange(prms.ToArray());
        SQLiteDataReader reader = g.ExecuteReader();
        ....
    }
