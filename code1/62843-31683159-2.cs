     protected override void OnAuthorization(AuthorizationContext filterContext)
     {
          if(!User.IsInRole("Admin")
          {
              base.OnAuthorization(filterContext);
              filterContext.RequestContext.HttpContext.Response.Redirect("/Login", true);
          }
     }
