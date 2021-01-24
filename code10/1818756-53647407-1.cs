    public class MyCustomActionFilter : ActionFilterAttribute
    {
        private readonly Container _container;
        public MyCustomActionFilter(Container container)
        {
            _container = container;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            myService = container.GetService<IMyService>();
            //actual code of custom filter removed - use of MyService 
        }
    }
