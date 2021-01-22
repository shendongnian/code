    public class RedirectFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Url;
            var urlWithoutQuery = url.GetLeftPart(UriPartial.Path);
            if (Regex.IsMatch(urlWithoutQuery, @"[A-Z]"))
            {
                string lowercaseURL = urlWithoutQuery.ToString().ToLower() + url.Query;
                filterContext.Result = new RedirectResult(lowercaseURL, permanent: true);
            }
    
            base.OnActionExecuting(filterContext);
        }
    }
