        public class RequireRegistrationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;
            HttpResponseBase response = filterContext.HttpContext.Response;
            if (request != null && 
                response != null)
            {
                bool isAuthenticated = request.IsAuthenticated;
                filterContext.Controller.ViewData["IsAuthenticated"] = isAuthenticated;
                if (!isAuthenticated)
                {
                    string url = String.Format(
                       "/?ReturnUrl={0}", 
                       HttpUtility.UrlEncode(request.Url.ToString()));
                    response.Redirect(url);
                }
            }
        }
    }
