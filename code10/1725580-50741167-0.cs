    public class CallManagerCache : ICallManagerMethods{
		
		
		private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer
			.Connect(CloudConfigurationManager.GetSetting("RedisConnectionString")));
			
		public static ConnectionMultiplexer cacheConnection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
		
		/// <summary>
        /// 	Here you save the value in cache, you get the connection, then StringSetAsync is in charge of saving the value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="template"></param>
		public async Task UpdateCallInstance(int id, byte[] data, bool instanceForCallback = false, TimeSpan? timespan = null)
        {
            var cache = cacheConnection.GetDatabase();
            await cache.StringSetAsync(instanceForCallback ? $"Call_{id}" : id.ToString(), data, timespan ?? new TimeSpan(0, 0, 15, 0));
        }
		
		/// <summary>
        /// 	Here you get the value in cache, you get the connection, then StringGetAsync is in charge of getting the value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="template"></param>
		public async Task<CallInstance> GetById(int id, bool isForCallback)
        {
            var cache = cacheConnection.GetDatabase();
            var callInstance = new CallInstance
            {
                Id = id,
                InstanceData = await cache.StringGetAsync(isForCallback ? $"Call_{id}" : id.ToString())
            };
            return callInstance;
        }
	}
    
