        public class ExceptionModule : IHttpModule
        {
            #region IHttpModule Members
    
            public void Dispose()
            {
                
            }
        
        /// <summary>
        /// Init method to register the event handlers for 
        /// the HttpApplication
        /// </summary>
        /// <param name="application">Http Application object</param>
        public void Init(HttpApplication application)
        {
            application.Error += this.Application_Error;
        }
    
    
     
    
        private void Application_Error(object sender, EventArgs e)
        {
            
                        // Create HttpApplication and HttpContext objects to access
                        // request and response properties.
                        var application = (HttpApplication)sender;
                        var context = application.Context;
                        application.Session["errorData"] = "yes there is an error";
                        
                        context.Server.Transfer("Error.aspx");
                        
             }
    }
