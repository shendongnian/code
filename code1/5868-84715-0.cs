    protected void Application_EndRequest(object sender, EventArgs e) {
        if (Context.Items["Send401"] != null)
        {
             Response.StatusCode = 401;
             Response.StatusDescription = "Unauthorized";
        } }
