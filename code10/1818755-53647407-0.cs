    public class MyCustomActionFilter : ActionFilterAttribute
    {
        private readonly IMyService _myService;
        public MyCustomActionFilter(Container container)
        {
            _myService = container.GetService<IMyService>(); // NEVER DO THIS!!!
        }
        ...
    }
