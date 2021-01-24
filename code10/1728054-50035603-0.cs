    public class ActionExecutionTimeAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Items["ActionName"] = filterContext.HttpContext.Request.RawUrl;
                filterContext.HttpContext.Items["StartTime"] = DateTime.UtcNow;
                base.OnActionExecuting(filterContext);
            }
            // Do this to calculate only Action Execution Time
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
                DateTime startTime = (DateTime)filterContext.HttpContext.Items["StartTime"];
                System.Diagnostics.Debug.WriteLine(filterContext.HttpContext.Items["ActionName"].ToString() + "-" + (DateTime.UtcNow - startTime).TotalMilliseconds);
            }
            // Do this to calcution of Action Start to Result Process
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                base.OnResultExecuted(filterContext);
                DateTime startTime = (DateTime)filterContext.HttpContext.Items["StartTime"];
                System.Diagnostics.Debug.WriteLine(filterContext.HttpContext.Items["ActionName"].ToString() + "- (R)" + (DateTime.UtcNow - startTime).TotalMilliseconds);
            }
        }
