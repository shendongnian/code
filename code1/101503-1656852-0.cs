    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class RespondToAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var resultFormat = filterContext.RouteData.Values["resultFormat"] as string ?? "html";
            ViewResult viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
            {
                // The controller action did not return a view, probably it redirected
                return;
            }
            var model = viewResult.ViewData.Model;
            if (string.Equals("json", resultFormat, StringComparison.OrdinalIgnoreCase))
            {
                filterContext.Result = new JsonResult { Data = model };
            }
            // TODO: you could add some other response types you would like to handle
        }
    }
