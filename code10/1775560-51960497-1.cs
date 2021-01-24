    using( var context = new myDbContext())
    {
       var query = context.Orders.SqlQuery(sql);
       // ...
       var results = query.ToList();
    }
