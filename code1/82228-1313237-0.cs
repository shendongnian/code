    public class MyCustomFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["TheUser"] = User.Identity.IsAuthenticated ? UserRepository.GetUser(User.Identity.Name) : null;
            base.OnActionExecuting(filterContext);
        }
    }
