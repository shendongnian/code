    ObjectFactory.Initialize(x =>
    {
        x.UseDefaultStructureMapConfigFile = false;
        x.ForRequestedType<ICustomerRepository>()
            .TheDefaultIsConcreteType<CustomerRepository>()
            .CacheBy(InstanceScope.Singleton);
    
        x.ForRequestedType<ICustomerService>()
            .TheDefaultIsConcreteType<CustomerService>()
            .CacheBy(InstanceScope.Singleton);
    
        x.ForConcreteType<Form1>();
     });
