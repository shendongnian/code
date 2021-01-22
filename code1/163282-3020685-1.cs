    bool exists;
    try
    {
        // ANSI SQL way.  Works in PostgreSQL, MSSQL, MySQL.  
        var cmd = new OdbcCommand(
          "select case when exists((select * from information_schema.tables where table_name = '" + tableName + "')) then 1 else 0 end");
        exists = (int)cmd.ExecuteScalar() == 1;
    }
    catch
    {
        try
        {
            // Other RDBMS.  Graceful degradation
            exists = true;
            var cmdOthers = new OdbcCommand("select 1 from " + tableName + " where 1 = 0");
            cmdOthers.ExecuteNonQuery();
        }
        catch
        {
            exists = false;
        }
    }
