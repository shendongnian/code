    public class UrlRewrite : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }
    
        private void Application_BeginRequest(Object source, EventArgs e)
        {
            // The RawUrl will look like:
            // http://domain.com/404.aspx;http://domain.com/Posts/SomePost/
            if (HttpContext.Current.Request.RawUrl.Contains(";")
                && HttpContext.Current.Request.RawUrl.Contains("404.aspx"))
            {
                // This places the originally entered URL into url[1]
                string[] url = HttpContext.Current.Request.RawUrl.ToString().Split(';');
    
                // Now parse the URL and redirect to where you want to go, 
                // you can use a XML file to store mappings between short urls and real ourls.
    
                string newUrl = parseYourUrl(url[1]);
                Response.Redirect(newUrl);
            }
    
            // If we get here, then the actual contents of 404.aspx will get loaded.
        }
    
        public void Dispose()
        {
            // Needed for implementing the interface IHttpModule.
        }
    }
