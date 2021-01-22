    // ...
    
    public void Init(HttpApplication application)
    {
        // ...
        application.EndRequest += (new EventHandler(this.Application_EndRequest));
    }
    private void Application_EndRequest(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)source;
        HttpContext context = application.Context;
        context.Current.Response.Flush();
    }
