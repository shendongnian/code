    private void context_BeginRequest(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;
    
        string ext = System.IO.Path.GetExtension(context.Request.Path);
        // ext will always start with dot
     
    }
