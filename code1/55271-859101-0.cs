[MyFilter("MyAction")]
public class HomeController : Controller
{
    public ActionResult Action1...
    public ActionResult Action2...
    public ActionResult MyAction...
}
public class CompressFilter : ActionFilterAttribute
{
    private IList<string> _ExcludeActions = null;
    public CompressFilter()
    {
        _ExcludeActions = new List<string>();
    }
    public CompressFilter(string excludeActions)
    {
        _ExcludeActions = new List<string>(excludeActions.Split(','));
    }
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        HttpRequestBase request = filterContext.HttpContext.Request;
        string currentActionName = (string)filterContext.RouteData.Values["action"];
        if (_ExcludeActions.Contains(currentActionName))
            return;
        ...
    }
