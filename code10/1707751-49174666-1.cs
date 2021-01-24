    Container.RegisterType<ConnectUserManager>(
        new PerRequestLifetimeManager(),
        new InjectionFactory(
            container => new ConnectUserManager(
                container.Resolve<ConnectDbContext>(),
                container.Resolve<ITemplateManager>(),
                Settings.MaxFailedAccessAttemptsBeforeLockout,
                Settings.AccountLockoutTimeSpan)));
