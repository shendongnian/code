    Container.Register(
    
      Component.For<Func<FoodieTenantContext, IRepository<CustomerRepository>>>()
               .Instance((FoodieTenantContext context) => Container.Resolve<IRepository<CustomerRepository>>(new {context = context}))
    )
