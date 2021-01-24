    public class MyFilter : ActionFilterAttribute
    {
        public MyFilter()
        {
        }
        //After Method execution
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //Do stuff
        }
        //Before Method execution
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Do stuff
        }
    }
