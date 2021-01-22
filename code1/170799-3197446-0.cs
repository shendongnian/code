    protected void Application_BeginRequest (object sender, EventArgs e)
    {
       if (!Request.Url.Host.StartsWith ("www") && !Request.Url.IsLoopback)
       {
          UriBuilder builder = new UriBuilder (Request.Url);
          builder.Host = "www." + Request.Url.Host;
          Response.Redirect (builder.ToString (), true);
       }
    }
