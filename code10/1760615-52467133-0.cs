    public class CurrencyPairCacheManagementService : BaseHostedService<CurrencyPairCacheManagementService>
            , ICurrencyPairCacheManagementService, IHostedService, IDisposable
        {
            private ICurrencyPairService _currencyPairService;
            private IConnectionMultiplexer _connectionMultiplexer;
            
            public CurrencyPairCacheManagementService(IConnectionMultiplexer connectionMultiplexer,
                IServiceProvider serviceProvider) : base(serviceProvider)
            {
                _currencyPairService = serviceProvider.GetService<CurrencyPairService>();
                _connectionMultiplexer = connectionMultiplexer;
                
                InitializeCache(serviceProvider);
            }
    
            /// <summary>
            /// Operation Procedure for CurrencyPair Cache Management.
            ///
            /// Updates every 5 seconds.
            ///
            /// Objectives:
            /// 1. Pull the latest currency pair dataset from cold storage (DB)
            /// 2. Cross reference checking (MemoryCache vs Cold Storage)
            /// 3. Update Currency pairs
            /// </summary>
            /// <param name="stoppingToken"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                _logger.LogInformation("CurrencyPairCacheManagementService is starting.");
    
                stoppingToken.Register(() => _logger.LogInformation("CurrencyPairCacheManagementService is stopping."));
    
                while (!stoppingToken.IsCancellationRequested)
                {
                    var currencyPairs = _currencyPairService.GetAllActive();
                    
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
    
                _logger.LogWarning("CurrencyPairCacheManagementService background task is stopping.");
            }
    
            public void InitializeCache(IServiceProvider serviceProvider)
            {
                var currencyPairs = _currencyPairService.GetAllActive();
    
                // Load them individually to the cache.
                // This way, we won't have to update the entire collection if we were to remove, update or add one.
                foreach (var cPair in currencyPairs)
                {
                    // Naming convention => PREFIX + CURRENCYPAIRID
                    // Set the object into the cache
                    
                }
            }
    
            public Task InproPair(CurrencyPair currencyPair)
            {
                throw new NotImplementedException();
            }
        }
