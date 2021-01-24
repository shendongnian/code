    private BusinessListViewModel(IBusinessService businessService, IStringBuilder builder)
    {
        _businessService = businessService;
        _builder = builder;
    }
    public static async Task<BusinessListViewModel> Create(IBusinessService businessService, IStringBuilder builder)
    {
        var instance = new BusinessListViewModel(businessService, builder)
        await InitBusiness();
        return instance;
    }
     
