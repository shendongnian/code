    public int GetSqlCount<T>(Session session, string table)
    {
        var sql = String.Format("SELECT Count(*) FROM {0}", table);
        var query = session.CreateSQLQuery(sql);
        var result = query.UniqueResult();
    
        return Convert.ToInt32(result);
    }
