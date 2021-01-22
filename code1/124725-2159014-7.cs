    public class BaseController : Controller
    {
      public override void OnActionExecuted(ActionExecutedContext context)
      {
        base.OnActionExecuted(context);
        bool isAdministrator = context.HttpContext.Request.IsAuthenticated && context.HttpContext.User.IsInRole("Administrator");
        context.Controller.ViewData.Add("IsAdministrator", isAdministrator);
      }
    }
