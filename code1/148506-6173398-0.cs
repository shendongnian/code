    void Application_BeginRequest(object sender, EventArgs e)
    {
        if (Request.Url.AbsolutePath.Contains(...))
        {
            Response.Redirect("SomePage.aspx");
        }
    }
