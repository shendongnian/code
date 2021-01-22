    /// <summary>
    /// HTTP module to restrict access by IP address
    /// </summary>
    
    public class SecurityHttpModule : IHttpModule
    {
     public SecurityHttpModule() { }
    
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Application_BeginRequest);
        }
    
        private void Application_BeginRequest(object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;
            string ipAddress = context.Request.UserHostAddress;
            if (!IsValidIpAddress(ipAddress))
            {
                context.Response.StatusCode = 403;  // (Forbidden)
    
            }
        }
    
        private bool IsValidIpAddress(string ipAddress)
        {
            return (ipAddress == "127.0.0.1");
        }
    
        public void Dispose() { /* clean up */ }
    }
