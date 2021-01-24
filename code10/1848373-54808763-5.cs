    [TestMethod]
    public void PassingParametersToRegister_NamedParameter()
    {
        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterType<IOption1Factory1<SomeOption>>().As<IOptionFactory<IOption>>();
        builder.RegisterType<IOption1Factory2<SomeOption>>().As<IOptionFactory<IOption>>();
        builder.RegisterType<Reporting>();
        using (var container = builder.Build())
        {
            container.Resolve<Reporting>().Report();
        }
        //OUTPUT:
        //Enumerations + IOption1Factory1`1[Enumerations + SomeOption]
        //Enumerations + IOption1Factory2`1[Enumerations + SomeOption]
    }
