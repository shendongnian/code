    private readonly IServiceScopeFactory _scopeFactory;
    
    public Service(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    
    public void RunBackgroundTask()
    {    
        ThreadPool.QueueUserWorkItem(new WaitCallback(state => { 
            using (scope = _scopeFactory.CreateScope())
            {
                var dependencyService = scope.ServiceProvider.GetService(typeof(SecondService));
                // do your work here
            }));
        }
    }
