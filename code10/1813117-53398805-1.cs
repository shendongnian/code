    // Logger as property
    Logger = serviceProvider.GetService<ILogger>();
    var sampleService = new SampleService(Logger);
    
    // Called directly passed
    var sampleService = new SampleService(serviceProvider.GetService<ILogger>());
