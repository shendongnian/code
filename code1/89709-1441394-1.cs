    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
      private MyUser User { get; set; }
    
      public override void OnAuthorization(AuthorizationContext filterContext)
      {
        //Lazy loads the user in the controller.
        User = ((MyControllerBase)filterContext.Controller).User;
    
        base.OnAuthorization(filterContext);
      }
    
      protected override bool AuthorizeCore(HttpContextBase httpContext)
      {
        bool isAuthorized = false;
        string retLink = httpContext.Request.Url.AbsolutePath;
    
        if(User != null)
        {
          isAuthorized = User.IsValidated;
        }
    
        if (!isAuthorized)
        {
          //If the current request is coming in via an AJAX call,
          //simply return a basic 401 status code, otherwise, 
          //redirect to the login page.
          if (httpContext.Request.IsAjaxRequest())
          {
            httpContext.Response.StatusCode = 401;
          }
          else
          {
            httpContext.Response.Redirect("/login?retlink=" + retLink);
          }
        }
    
        return isAuthorized;
      }
    }
