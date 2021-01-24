    public class ThrottleAttribute : ActionFilterAttribute
    {
        private readonly IConfiguration _config;
        
        public string Count { get; set; }
        public ThrottleAttribute(IConfiguration config)
        {
            _config = config;
        }
        //rest of code omitted
    }
