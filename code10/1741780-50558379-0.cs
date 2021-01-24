    [AttributeUsage(AttributeTargets.Method)]
    public class FooActionFilterAttribute : ActionFilterAttribute
    {
        public FooActionFilterAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }
        
        public Type ServiceType { get; }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var service =  context.HttpContext.RequestServices.GetService(ServiceType) as IFooService;                   
        }
    }
    // usage
    [FooActionFilter(typeof(IFilterService<int>))]
    public IActionResult ActionMethod()
    {
    }
