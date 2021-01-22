    public sealed class AlternateOutputAttribute :
                        ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext aec)
        {
            ViewResult vr = aec.Result as ViewResult;
    
            if (vr == null) return;
    
            var aof = aec.RouteData.Values["alternateOutputFormat"] as String;
    
            if (aof == "json") aec.Result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = vr.ViewData.Model,
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
    }
