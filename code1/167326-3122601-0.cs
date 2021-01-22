    static string test; 
            public void Init(HttpApplication application)
            {
    
               
                application.BeginRequest +=(new EventHandler(this.Application_BeginRequest));
                test = "hi"; 
                application.EndRequest +=(new EventHandler(this.Application_EndRequest));
                
                                  
            }
           private void Application_BeginRequest(Object source,EventArgs e)
            {
                {
                    HttpApplication application = (HttpApplication)source ;
                    HttpContext context = application.Context;
                    context.Response.Write(test);
                }
    
               
            }
