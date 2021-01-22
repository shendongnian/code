            protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if ((Response.ContentType == "text/html") && (Request.IsAuthenticated))
            {
                
            }
        }
