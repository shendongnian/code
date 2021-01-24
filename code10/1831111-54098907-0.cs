    public string ExecuteQuery(string txtQuery)
    {
        SetConnection();
        sql_con.Open();
        sql_cmd = sql_con.CreateCommand();
        sql_cmd.CommandText = txtQuery;
        var x = sql_cmd.ExecuteQuery();
        sql_con.Close();
    return x;
    }
