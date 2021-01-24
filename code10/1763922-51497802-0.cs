    container.Register(
        Component.For<BranchRepository>(),
        Component.For<Func<FoodieTenantContext, BranchRepository>>()
        .Instance(c => container.Resolve<BranchRepository>(new { ctx = c }))
        .LifestyleTransient()
    );
