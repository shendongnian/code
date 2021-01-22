    public class BaseController : Controller
    {
      public override void OnActionExecuted(ActionExecutedContext context)
      {
        base.OnActionExecuted(context);
        var user = context.HttpContext.User;
        context.Controller.ViewData.Add("IsAdministrator", context.HttpContext.Request.IsAuthenticated && user.IsInRole("Administrator"));
      }
    }
