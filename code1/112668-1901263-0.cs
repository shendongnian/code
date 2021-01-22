    void context_Error(object sender, EventArgs e)
            {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            Exception ex = context.Server.GetLastError();
            //... here goes some code
            }
