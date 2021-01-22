    using System;
    using System.Web;
    
    namespace HttpsOnly
    {
        /// <summary>
        /// Redirects the Request to HTTPS if it comes in on an insecure channel.
        /// </summary>
        public class HttpsOnlyModule : IHttpModule
        {
            public void Init(HttpApplication app)
            {
                // Note we cannot trust IsSecureConnection when 
                // in a webfarm, because usually only the load balancer 
                // will come in on a secure port the request will be then 
                // internally redirected to local machine on a specified port.
    
                // Move this to a config file, if your behind a farm, 
                // set this to the local port used internally.
                int specialPort = 443;
    
                if (!app.Context.Request.IsSecureConnection 
                   || app.Context.Request.Url.Port != specialPort)
                {
                   app.Context.Response.Redirect("https://" 
                      + app.Context.Request.ServerVariables["HTTP_HOST"] 
                      + app.Context.Request.RawUrl);    
                }
            }
    
            public void Dispose()
            {
                // Needed for IHttpModule
            }
        }
    }
