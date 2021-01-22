    var builder = new ContainerBuilder();
    builder.Register<Car>();
    builder.Register<BmwEngine>();
    builder.Register<AudiEngine>();
    builder.Register<DefaultEngine>();
    builder.Register<EngineSelector>().As<IEngineSelector>().SingletonScope();
    builder.Register(
        c => {
                var selector = c.Resolve<IEngineSelector>();
                switch(selector.CurrentEngine)
                {
                    case "bmw":
                        return c.Resolve<BmwEngine>();
                    case "audi":
                        return c.Resolve<AudiEngine>();
                    default:
                        return c.Resolve<DefaultEngine>();
                }
            }
        ).As<IEngine>().FactoryScoped();
    
    var container = builder.Build();
    
    // somewhere in the code
    var selector = container.Resolve<IEngineSelector>();
    selector.CurrentEngine = "bmw";
    var car = container.Resolve<Car>();
