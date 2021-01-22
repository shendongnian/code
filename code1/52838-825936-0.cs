    // Bad example:
    
    string sql = "delete from Products where ProductName = " + rawUserInput;
    QueryCommand qry = new QueryCommand(sql, Product.Schema.Provider.Name);
    DataService.ExecuteQuery(qry);
    
    // Should be:
    
    string sql = "delete from Products where ProductName = @TargetName";
    QueryCommand qry = new QueryCommand(sql, Product.Schema.Provider.Name);
    qry.AddParamter("@TargetName", rawUserInput, DbType.String);
    DataService.ExecuteQuery(qry);
