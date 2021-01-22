    _mocks = new MockRepository();
    
    _container = new AutoMockingContainer(_mocks);
    _container.AddService(typeof(IActionRunner), new SyncActionRunner());
    _container.Initialize();
