    public class MyCustomAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Session != null)
                {
                    var request = context.HttpContext.Session["User"] as User;
                    if (request != null)
                    {
                        if (request.UserGroups.Contains("some_group"))
                        {
                            //do something
                        }
    
                        if (request.UserGroups.Contains(""))
                        {
                            // do something else
                        }
                        
                    }
                    else
                    {
                        //No group info, kinda BadRequest!
                        filterContext.Result = new RedirectResult("/index.html");
                    }
                }
            }
