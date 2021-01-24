        private readonly IDistributedCache _cache;
                public Constructor(IDistributedCache cache)
                {
                    _cache = cache;
                }
           
         public async Task<MyModel> GetWebApiData(double? latitude, double? longitude)
            {    
                   var key = $"MyKey";
                    var cachedValue = await _cache.GetAsync(key);
        
                    if (cachedValue == null)
                    {
                        data = "CallWebApi"
                        await SetDataToCache(key, data);
                    }
                    else
                    {
                        data = JsonConvert.DeserializeObject<MyModel>(Encoding.UTF8.GetString(cachedValue));
                    }
    }
        
        public async Task SetDataToCache(string key, MyModel data)
                {
                    if (data != null)
                    {
                        var json = JsonConvert.SerializeObject(data);
                        await _cache.SetAsync(key, Encoding.ASCII.GetBytes(json), new DistributedCacheEntryOptions()
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                        });
                    }
                }
