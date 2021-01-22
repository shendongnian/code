    using (var connection = container.Resolve<IDbConnection>())
    using (var context = container.Resolve<IMyDataContext>())
    {
        context.Connection = connection;
        // Do some stuff...
        context.SubmitChanges();
    }
