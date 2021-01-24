    public class AntiForgeryExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            // ANTIFORGERY TOKEN NOT PRESENT
            if (!filterContext.ExceptionHandled && filterContext.Exception is HttpAntiForgeryException)
            {
                var request = new HttpRequestWrapper(System.Web.HttpContext.Current.Request);
                // Use your own logging service to log the results
                var _logger = new LoggingService();
                foreach (var key in request.Form.AllKeys)
                {
                    var value = request.Form[key];
                    // "key" is the form input name and "value" is the form input value
                    _logger.Log("~~> " + key + " ==> " + value);
                }
    
                filterContext.ExceptionHandled = true;
            }
        }
    }
