    Container.RegisterType<ConnectUserManager>(
        new PerRequestLifetimeManager(),
        new InjectionConstructor(
            Container.Resolve<ConnectDbContext>(),
            Container.Resolve<ITemplateManager>(),
            Settings.MaxFailedAccessAttemptsBeforeLockout,
            Settings.AccountLockoutTimeSpan));
