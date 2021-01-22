    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, Inherited=true, AllowMultiple=false)]
    public class MyCustomFilterAttribute : ActionFilterAttribute
    {
        private MyCustomFilterMode _Mode = MyCustomFilterMode.Respect;        // this is the default, so don't always have to specify
        public MyCustomFilterAttribute()
        {
        }
        public MyCustomFilterAttribute(MyCustomFilterMode mode)
        {
            _Mode = mode;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_Mode == MyCustomFilterMode.Ignore)
            {
                return;
            }
            
            // Otherwise, respect the attribute and work your magic here!
            //
            //
            //
        }
        
    }
        
    public enum MyCustomFilterMode
    {
        Ignore = 0,
        Respect = 1
    }
    
