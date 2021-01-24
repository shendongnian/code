    [AttributeUsage(AttributeTargets.Method)]
    public class ThrottleAttribute : ActionFilterAttribute
    {
        public string Count { get; set; }
        public static string ConfigCount { get; set; }
    
        private static MemoryCache Cache { get; } = new MemoryCache(new MemoryCacheOptions());
    
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            //Compare this.Count with GetValueFromAppSettings.json
        }
    }
