     public class Log : FilterAttribute, IActionFilter, IResultFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var db = new SomeExampleEntities();
                WebLog webLog = new WebLog();
                webLog.LogDate = DateTime.Now;
                // Whatever you want to log
                webLog.Path = filterContext.HttpContext.Request.Path;
                webLog.IPAddress = filterContext.HttpContext.Request.UserHostAddress;
                webLog.SessionId = filterContext.HttpContext.Session.SessionID;
                db.WebLogs.Add(webLog);
                db.SaveChanges();
                filterContext.HttpContext.Items["WebLog"] = webLog;
                filterContext.HttpContext.Items["WebLog_db"] = db;
            }
            catch
            {
            }
        }
        // This is fired when leaving the controller action, before running the View/Result
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
                WebLog webLog = (WebLog)filterContext.HttpContext.Items["WebLog"];
                webLog.ActionElapsed = (decimal)(((TimeSpan)(DateTime.Now - webLog.LogDate)).TotalMilliseconds / 1000.0000);
        }
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Do Nothing
        }
        //This is fired after the result is actually executed, not just after the Action returns a View or Result
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                UsisWebEntities db = (UsisWebEntities)filterContext.HttpContext.Items["WebLog_db"];
                WebLog webLog = (WebLog)filterContext.HttpContext.Items["WebLog"];
                webLog.Elapsed = (decimal)(((TimeSpan)(DateTime.Now - webLog.LogDate)).TotalMilliseconds / 1000.0000);
                webLog.ResultElapsed = webLog.Elapsed - webLog.ActionElapsed;
                db.SaveChanges();
            }
            catch 
            {
            }
        }
    }
