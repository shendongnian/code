    public abstract class BaseController : Controller
    {
        protected override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            var responseCode = Response.StatusCode;
            var exception = filterContext.Exception;
            switch (exception.GetType().ToString())
            {
                case "ArgumentNullException":
                    responseCode = 500;
                    break;
                default:
                    responseCode = 401;
                    break;
            }
            Response.StatusCode = responseCode;
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
