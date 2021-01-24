    protected void Application_BeginRequest(object sender, EventArgs e)
            {
                if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
                {
                    Response.End();
                }
    }
