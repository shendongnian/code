    public class NormalizeUrl : ActionFilterAttribute {
        private bool ForceHttps = false;
        private bool ForceWww = false;
        public NormalizeUrl(
            bool ForceHttps,
            bool ForceWww) {
            this.ForceHttps = ForceHttps;
            this.ForceWww = ForceWww;
        }
        public override void OnActionExecuting(
            ActionExecutingContext Context) {
            HttpRequestBase Request = Context.HttpContext.Request;
            HttpResponseBase Response = Context.HttpContext.Response;
            if (!Request.IsLocal) {
                if (!Request.IsSecureConnection && this.ForceHttps) {   //  http://domain.com OR http://www.domain.com
                    if (this.ForceWww && !Request.Url.Host.Contains("www.")) {  //  http://domain.com
                        Response.RedirectPermanent(new Uri(Uri.UriSchemeHttps + "://www." + Request.Url.Host + Request.Url.AbsolutePath).AbsoluteUri, true);
                    } else {    //  http://www.domain.com
                        Response.RedirectPermanent(new Uri(Uri.UriSchemeHttps + "://" + Request.Url.Host + Request.Url.AbsolutePath).AbsoluteUri, true);
                    };
                } else {
                    if (this.ForceWww && !Request.Url.Host.Contains("www.")) {  //  http://domain.com OR https://domain.com
                        Response.RedirectPermanent(new Uri(Request.Url.Scheme + "://www." + Request.Url.Host + Request.Url.AbsolutePath).AbsoluteUri, true);
                    };
                };
            };
        }
    }
