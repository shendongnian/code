    Container.RegisterType<IUserRepository>(CreationPolicy.Shared);
    using (var disposable = Container.Resolve<IDisposableObject>()) {
        var userRepository = Container.Resolve<IUserRepository>();
        // only one instance of user repository is created and persisted by the container.
    }
