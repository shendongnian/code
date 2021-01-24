    public class RedisCacheHelper
    {
        public StackExchangeRedisCacheClient Cache {get;set;}
        public RedisCacheHelper(RedisConfiguration redisconfig)
        {
            Cache = new StackExchangeRedisCacheClient(new NewtonsoftSerializer(),redisconfig );
        }
    
    }
