    [HttpGet]
    [AllowAnonymous]
    [DoNotExtendAuthentication]
    public ActionResult IsAuthenticated(string url)
    {
        var isAuthenticated = HttpContext?.User?.Identity?.IsAuthenticated ?? false;
         return Json(isAuthenticated); // change this line to whatever shape of JSON you want
    }
    public class DoNotExtendAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Cookies.Remove(
                FormsAuthentication.FormsCookieName);
        }
    }
