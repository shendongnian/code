    /// <summary>
    /// Construct a DataAdapater based on the type of DbConnection passed.
    /// You can call connection.CreateCommand() to create a DbCommand object,
    /// but there's no corresponding connection.CreateDataAdapter() method.
    /// </summary>
    /// <param name="connection"></param>
    /// <exception>Throws Exception if the connection is not of a known type.</exception>
    /// <returns></returns>
    public static DbDataAdapter CreateDataAdapter(DbConnection connection)
    {
       DbDataAdapter adapter; //we can't construct an adapter directly
             //So let's run around the block 3 times, before potentially crashing
       if (connection is System.Data.SqlClient.SqlConnection)
          adapter = new System.Data.SqlClient.SqlDataAdapter();
       else if (connection is System.Data.OleDb.OleDbConnection)
          adapter = new System.Data.OleDb.OleDbDataAdapter();
       else if (connection is System.Data.Odbc.OdbcConnection)
          adapter = new System.Data.Odbc.OdbcDataAdapter();
       //TODO: Add more DbConnection kinds as they become invented
       else
       {
          throw new Exception("[CreateDataAdapter] Unknown DbConnection type: " + connection.GetType().FullName);
       }
       return adapter;
    }
