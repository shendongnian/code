    public class HttpHeadersLogger : ActionFilterAttribute
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var builder = new StringBuilder();
    
            builder.Append(request.RequestType + " " + request.Url + "\n");
    
            var logEventInfo = new LogEventInfo(LogLevel.Info, null, null);
            var parsed = HttpUtility.ParseQueryString(request.Headers.ToString());
    
            foreach (string key in parsed)
            {
                // Search for 'tid' header here to only log these one
                logEventInfo.Properties.Add(key, parsed[key]);
            }
    
            _log.Log(logEventInfo);
    
            base.OnActionExecuting(filterContext);
        }
    }
