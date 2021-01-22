    class DBWrapper:IDisposable { private SqlConnection sqlConn;
    public void EnsureConnectionIsOpen()
    {
        if (sqlConn == null)
        {
          sqlConn = new SqlConnection("my connection string");
          sqlConn.Open();
        }
        
    }
    public DataTable RunQuery(string Sql)
    {
        EnsureConnectionIsOpen();
        implementation......
    }
    public Dispose()
    {
       if(sqlConn != null)
                  sqlConn.Close();
    }
    } 
