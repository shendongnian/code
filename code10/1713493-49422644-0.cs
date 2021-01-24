    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      var builder = new ContainerBuilder();
      builder.RegisterType<MyType>().As<IMyType>();
      builder.Populate(services);
      this.ApplicationContainer = builder.Build();
      return new AutofacServiceProvider(this.ApplicationContainer);
    }
