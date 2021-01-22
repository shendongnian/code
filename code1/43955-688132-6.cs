    static string GetRelation<TEntity>(this TEntity entity, params TEntity[] path)
     where TEntity : Type
    {
       string ret = entity.Name;
       foreach (TEntity type in path) ret += "." + type.Name;
       return ret;
    }
    //Put your line here:
    var x = context.Employee.Include(typeof(Contact).GetRelation(
     typeof(SalesOrderHeader),
     typeof salesOrderDetail)));
                                           
