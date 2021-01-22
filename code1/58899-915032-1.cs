    public SqlConnection Connection()
    {
      if(sqlConn == null) sqlConn = new SqlConnection(connStr); // <== edit
      return sqlConn;
    }
