    IUserContext
    {
    int param1 {get;set;}
    int param2 {get;set;}
    
    SqlParameter[] GetSqlParameters();
    }
    
    UserContext : IUserContext{}
    
    UserContextFactory
    {
        internal IUserContext IUserContextFromRequest(){}
    }
