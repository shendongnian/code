    public List<Page> GetPage(IDbConnection dbConnection, string sql)
    {
        return (List<Page>)dbConnection.Query<Page, User, Page>(sql, 
            MappingDynamicFunc<Page, User>(),
            splitOn: "IdUser").ToList();  
    }
