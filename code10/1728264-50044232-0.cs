     public string RenderPartialView(string controllerName, string viewName, object model = null) {
         System.Web.HttpContextBase contextBase = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current);
    
         var routeData = new RouteData();
         routeData.Values.Add("controller", controllerName);
         var controllerContext = new System.Web.Mvc.ControllerContext(contextBase, routeData,
          new EmptyController());
    
         var razorViewEngine = new System.Web.Mvc.RazorViewEngine();
         var razorViewResult = razorViewEngine.FindPartialView(controllerContext, viewName, false);
    
         var writer = new StringWriter();
         System.Web.Mvc.ViewContext viewContext;
    
    
         viewContext = new System.Web.Mvc.ViewContext(controllerContext, razorViewResult.View,
          new System.Web.Mvc.ViewDataDictionary(model), new System.Web.Mvc.TempDataDictionary(), writer);
    
         viewContext.ViewData["controller"] = controllerName;
    
         HttpContext.Current.Items.Add("controller", controllerName);
    
         razorViewResult.View.Render(viewContext, writer);
    
         string htmlString = writer.ToString();
         writer.Dispose();
    
         return htmlString;
        }
----------------------------------------------------------------------------
 
    private class EmptyController: System.Web.Mvc.ControllerBase {
      protected override void ExecuteCore() {}
     }
