    public abstract class BaseController : Controller
    {
        protected override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            var responseCode = Response.StatusCode;
            var exception = filterContext.Exception;
            switch (exception.GetType().ToString())
            {
                case "UnauthorizedAccessException":
                    responseCode = 401;
                    filterContext.ExceptionHandled = true;
                    break;
            }
            Response.StatusCode = responseCode;
            
            base.OnException(filterContext);
        }
    }
