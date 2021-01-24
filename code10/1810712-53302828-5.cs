    public class name
    {   
        private readonly AppKeys classname;   
        public RedisClient(IOptions<AppKeys> value)
    	{
    		 classname = value.Value;
    	}
    }
