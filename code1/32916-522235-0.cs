    public class SeoUrls : IHttpModule
    {
      #region IHttpModule Members
      public void Init(HttpApplication context)
      {
          context.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
      }
      public void Dispose()
      {
      }
      #endregion
      private void OnPreRequestHandlerExecute(object sender, EventArgs e)
      {
        HttpContext ctx = ((HttpApplication) sender).Context;
        IHttpHandler handler = ctx.Handler;
        // Only worry about redirecting pages at this point
        // static files might be coming from a different domain
        if (handler is Page)
        {
          if (Ctx.Request.Url.Host != WebConfigurationManager.AppSettings["FullHost"])
          {
            UriBuilder uri = new UriBuilder(ctx.Request.Url);
            
            uri.Host = WebConfigurationManager.AppSettings["FullHost"];
            // Perform a permanent redirect - I've generally implemented this as an 
            // extension method so I can use Response.PermanentRedirect(uri)
            // but expanded here for obviousness:
            response.AddHeader("Location", uri);
            response.StatusCode = 301;
            response.StatusDescription = "Moved Permanently";
            response.End();
          }
        }
      }
    }
