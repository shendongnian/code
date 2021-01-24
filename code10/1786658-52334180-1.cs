    public List<T> GetCollection<T>(StoredProcedureVariables args, int timeout = -1) 
        where T: IReturnClass1, new()
    {
        var sqlDao = new DaoSqlServer();
        var sqlCmd = sqlDao.GetSprocCommand("stored_procedure_name");
        if (timeout >= 0) sqlCmd.CommandTimeout = timeout;
        sqlCmd.Parameters.Add(sqlDao.CreateParameter("variableString", args.VariableString));
        return (List<T>)Convert.ChangeType(sqlDao.GetList(sqlCmd, new T().Create).ToList(), typeof(T));
    }
