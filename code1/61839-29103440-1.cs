    private SqlConnection OpenConnection
    {
      get {
        var con = new SqlConnection(SQL_CONNECTION);
        con.Open();
        return con;
      }
    }
