    private readonly IServiceScopeFactory _scopeFactory;
    public UpdateService(AuthorizedServiceService authorizedServiceService, CustomerService customerService, IServiceScopeFactory scopeFactory)
    {
        _authorizedServiceService = authorizedServiceService;
        _customerService = customerService;
        _scopeFactory = scopeFactory;
    }
    
    public void UpdateStart(AuthorizedService authorizedService)
    {    
        ThreadPool.QueueUserWorkItem(new WaitCallback(state => { 
        using (scope = _scopeFactory.CreateScope())
        {
            var scopedAuthorizedService = scope.ServiceProvider.GetService(typeof(AuthorizedServiceService));
            UpdateCustomers(scopedAuthorizedService); }));
        }
     }
