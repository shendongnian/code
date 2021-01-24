    // get a new service instance with every call
    var brandNewService = ServiceProvider.Get<IService>();
    // get a deferred created singleton
    var sameOldService = ServiceProvider.Get<ILazyService>();
    // get a service which uses DI in its contructor
    var another service = ServiceProvider.Get<ILazyServiceWithDI>();
