    public int GetSqlCount<T>(Session session, string table)
    {
        var sql = String.Format("SELECT Count(*) FROM {0}", table);
        var query = session.CreateSQLQuery(sql);
        var result = query.UniqueResult();
        // Could also use this if only updating values:
        //query.ExecuteUpdate();
    
        return Convert.ToInt32(result);
    }
