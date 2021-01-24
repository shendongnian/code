    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExampleActionFilterAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ExampleActionFilter>();
        }
    }
