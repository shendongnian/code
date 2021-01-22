    protected void Application_BeginRequest (object sender, EventArgs e)
    {
       if (!Request.Url.Host.StartsWith ("www") && !Request.Url.IsLoopback)
       {
          UriBuilder builder = new UriBuilder (Request.Url);
          builder.Host = "www." + Request.Url.Host;
          Response.StatusCode = 301;
          Response.AddHeader ("Location", builder.ToString ());
          Response.End ();
       }
    }
