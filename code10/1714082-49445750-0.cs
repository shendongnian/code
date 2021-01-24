    public void RegisterTypes(IUnityContainer container)
    {
        //repository registration
        container.RegisterType<IFooRepository, FooRepository>();
        //services registration
        container.RegisterType<IFooService, FooService>();
     
        container.RegisterType<Program>();
    }
