    DbFunctions dfunc = null;
    IQueryable<TableName> lQueryableTableName = lObjInitDbContext.gObjServerAuditHistoryDbContext
       .ServerAuditHistorys
       .Where(x => SqlServerDbFunctionsExtensions
           .DateDiffMinute(dfunc, Convert.ToDateTime(Date1), Convert.ToDateTime(Date2)) < 1);
