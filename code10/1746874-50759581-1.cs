    IOC.Kernel.Bind<IDbConnection>().ToMethod(ctx =>
    {
        var cn = new DbConnectionFactory();
        return cn.GetConnection();
    }).InThreadScope();
