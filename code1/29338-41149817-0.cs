    private bool TableExists(string database, string name)
    {
        string strCmd = null;
        SqlCommand sqlCmd = null;
        try
        {
            //Support for ANSI SQL (works in PostgreSQL, MSSQL, MySQL)
            strCmd = "select case when exists((select * from information_schema.tables where schema_name = '" + database + "' and table_name = '" + name + "')) then 1 else 0 end";
            sqlCmd = new SqlCommand(strCmd);
            return (int)sqlCmd.ExecuteScalar() == 1;
        }
        catch
        {
            //Support for other RDBMS (graceful degradation)
            try
            {
                strCmd = "select 1 from " + name + " where 1 = 0";
                sqlCmd = new SqlCommand(strCmd);
                sqlCmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
