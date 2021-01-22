     ObjectFactory.Initialize(x =>
            {
                x.For(typeof(DbConnection)).Use(typeof(SqlConnection));
                x.For(typeof(IGenericRepository<>)).Use(typeof(GenericRepository<>));
            });
