    public static class ServerHelper {
    
      public static void Transfer(ActionExecutingContext filterContext, string url) {
    		
        // Rewrite path
        HttpContext.Current.RewritePath(GetPath(filterContext, url), false);
    		
        IHttpHandler httpHandler = new System.Web.Mvc.MvcHttpHandler();
    
        // Process request
        httpHandler.ProcessRequest(HttpContext.Current);
        filterContext.HttpContext.Response.End();
      }
    
      private static string GetPath(ActionExecutingContext filterContext, string url) {
          HttpRequestBase request = filterContext.HttpContext.Request;
    
          UriBuilder uriBuilder = new UriBuilder(request.Url.Scheme, request.Url.Host, request.Url.Port, request.ApplicationPath);
    										
          uriBuilder.Path += url;
    
          return filterContext.HttpContext.Server.UrlDecode(uriBuilder.Uri.PathAndQuery);
      }
    }
