        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          if (filterContext.RouteData.Values["action"] == "edit" && !IsProperTypeofId()) 
             RedirectToRoute(filterContext, new { controller = "General", action = "Error", id = 401 });
         
          base.OnActionExecuting(filterContext);
        }
