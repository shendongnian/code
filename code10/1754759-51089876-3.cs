    public class ThrottleAttributeFactory: ActionFilterAttribute, IFilterFactory
    {
        public string Count { get; set; }
    
        public bool IsReusable => false;
    
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var attribute = serviceProvider.GetService<ThrottleAttribute>();
    
            attribute.Count = Count;
    
            return attribute;
        }
    }
