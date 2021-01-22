    using (var repository = Container.Resolve<IUserRepository>())
    {
      var other = Container.Resolve<IUserRepository>();
      // should resolve to the same instance.
    }
