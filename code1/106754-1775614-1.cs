    var newServiceCreater = new GenericFactory(container);
    container.Register<Provider<MyCompoent>>().To(newServiceCreater.Create);
    var newServiceCreater = new GenericFactory(container);
    container
        .Register<Provider<OtherServiceWithOneArgumentToConstruct>>()
        .To(newServiceCreater.Create);
