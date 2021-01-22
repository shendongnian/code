    var builder = new ContainerBuilder();
    builder.Register<CustomerRepository>()
            .As<ICustomerRepository>()
            .ContainerScoped();
    builder.Register<CustomerService>()
            .As<ICustomerService>()
            .ContainerScoped();
    builder.Register<Form1>();
