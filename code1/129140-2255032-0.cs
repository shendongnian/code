    private void Application_BeginRequest(Object source, EventArgs e)
    {
        HttpContext context = ((HttpApplication)source).Context;
        HttpRequest request = context.Request;
        if(request.Url.ToString().Contains("blah.jpg"))
        {
            context.RewritePath("~/login.aspx?");
        }
    }
