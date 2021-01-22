     public sealed class HandleConnectionSecurityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase req = filterContext.HttpContext.Request;
            HttpResponseBase res = filterContext.HttpContext.Response;
    
            if (!filterContext.ActionDescriptor.IsDefined(typeof(RequiresSSL), true) && HttpContext.Current.Request.IsSecureConnection)
            {
                var builder = new UriBuilder(req.Url)
                {
                    Scheme = Uri.UriSchemeHttp,
                    Port = 80
                };
                res.Redirect(builder.Uri.ToString());
            }
    
            base.OnActionExecuting(filterContext);
        }
    }
