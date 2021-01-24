    protected void Application_Error(object sender, EventArgs e)
    {
         Exception exception = Server.GetLastError();
    
         HttpException httpException = exception as HttpException;
    
         if (httpException != null)
         {
             if (httpException.GetHttpCode() == 404)
             {
                  Server.ClearError();
                  Response.Redirect("~/Home/PageNotFound");
                  return;
             }
         }
                
         //Ignore from here if don't want to store the error in database
         HttpContextBase context = new HttpContextWrapper(HttpContext.Current);
         RouteData routeData = RouteTable.Routes.GetRouteData(context);
    
         string controllerName = null;
         string actionName = null;
         if (routeData != null)
         {
             controllerName = routeData.GetRequiredString("controller");
             actionName = routeData.GetRequiredString("action");
         }
    
    
         ExceptionModel exceptionModel = new ExceptionModel()
         {
             ControllerName = controllerName ?? "Not in controller",
             ActionOrMethodName = actionName ?? "Not in Action",
             ExceptionMessage = exception.Message,
             InnerExceptionMessage = exception.InnerException != null ? exception.InnerException.Message : "No Inner exception",
             ExceptionTime = DateTime.Now
         };
    
         using (YourDbContext dbContext = new YourDbContext())
         {
             dbContext.Exceptions.Add(exceptionModel);
             dbContext.SaveChanges();
         }
        // Ignore till here if you don't want to store the error on database
                
        // clear error on server
        Server.ClearError();
        Response.Redirect("~/Home/Error");
    }
