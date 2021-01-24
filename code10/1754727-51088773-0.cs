    container.Register<IDbConnectionFactory>(c =>
        new OrmLiteConnectionFactory(_sqliteFileDb, SqliteDialect.Provider));
    using (var db = container.Resolve<IDbConnectionFactory>().Open())
    {
        SeedData(db);
    }
