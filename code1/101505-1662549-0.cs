    public class ResultFormatAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext c)
        {
            ViewResult vr = c.Result as ViewResult;
    
            if (vr == null) return;
    
            if (c.RouteData.Values.ContainsValue("json")) c.Result = new JsonResult
            {
                Data = vr.ViewData.Model,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
    }
