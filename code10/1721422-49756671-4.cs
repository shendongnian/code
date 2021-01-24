    public dynamic RunReturningVar(
        string vstrSql, 
        bool connval,
        double copyID,
        bool corpVal,
        int vintConnectionTimeout) 
    {
        // do your stuff here 
    }
    public dynamic RunReturningVar(
        string vstrSql, 
        bool connval,
        double copyID,
        bool corpVal
        ) 
    {
        return RunReturningVar(vstrSql, connval, copyID, corpVal, 30);
    }
    public dynamic RunReturningVar(
        string vstrSql, 
        bool connval,
        double copyID,
        ) 
    {
        return RunReturningVar(vstrSql, connval, copyID, false);
    }
