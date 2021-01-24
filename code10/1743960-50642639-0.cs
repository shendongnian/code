    public BinanceService(IAPICacheManager apiCache, string instanceName, List<object> tracking, IDataService dataService, IMapper mappingEngine) : base(instanceName, tracking)
        {
            _mappingEngine = mappingEngine;
            _dataService = dataService;
            if (apiCache != null)
            {
                _apiCache = apiCache;
                _cacheEnabled = true;
    .....
