    public class BaseController: Controller
    {
       public override OnActionExecuting(...) { ... }
       public override OnActionExecuted(... context) 
       {
           if (context.Result is ViewResult)
               ((ViewResult)context.Result).ViewData["mycommondata"] = data;
       }
       ...
    }
    
    public class MyController1: BaseController 
    {
    }
