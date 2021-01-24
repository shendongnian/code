    foreach (var batch in data.Split(10))
    {
        using (var scope = LifetimeScope.BeginLifetimeScope("UnitOfWork", b =>
        {
            b.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
            b.RegisterType<MyService>().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
            b.RegisterGeneric(typeof(EntityBaseRepository<>)).As(typeof(IEntityBaseRepository<>)).InstancePerLifetimeScope();
        }))
        {
            UnitOfWork = scope.Resolve<IUnitOfWork>();
            MyService = scope.Resolve<IMyService>();
    
            foreach (var row in batch)
            {
                try
                {
                    ParseRow(row);
                }
                catch (Exception e)
                {
                    JobLogger.Error(e, "Failed to parse row. Exception: " + e.Message);
                    throw;
                }
    
            }
        }
    }
