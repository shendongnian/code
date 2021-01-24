      public void ConfigureServices(IServiceCollection services)
        {            
            // Scans assemblies and adds MediatR handlers, preprocessors, and postprocessors implementations to the container.            
            services.AddMediatR(typeof(Application.Logic.Queries.FindUserByEmailAddressHandler));
            var localDb = new LocalDb();
            services.AddSingleton<ILocalDb, LocalDb>(uow => localDb);
            services.AddSingleton<IUnitOfWork, UnitOfWork>(uow => new UnitOfWork(localDb.ConnectionString));
            services.AddSingleton<IUserRepository, UserRepository>();
        }
