    public void BeginTransaction()
    {
       // SelectCmd = Conn.CreateCommand();  //Problem Line
        MySqlTransaction NewTransaction = Conn.BeginTransaction();
        SelectCmd.Connection = Conn;
        SelectCmd.Transaction = NewTransaction;
    }
