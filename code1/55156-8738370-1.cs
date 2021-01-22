    public interface CustomInterceptor : IInterceptor, EmptyInterceptor
    {    
     SqlString IInterceptor.OnPrepareStatement(SqlString sql)
     {
        string query = sql.ToString();
         if (query.Contains("InnerJoin "))
         {
            sql = sql.Replace("InnerJoin ", "(select [vals] form dbo.DailyInfo [where conditions])");
         }
         return sql;
     }
    }
