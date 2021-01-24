    builder.Register(c =>
    {
         var conn = c.Resolve<IDbConnection>();
         return conn.BeginTransaction(IsolationLevel.ReadCommitted);
    });
