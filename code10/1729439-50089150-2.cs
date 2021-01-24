    public static class WidgetHelper
    {
        public static T CreateController<T>(RouteData routeData = null) where T : Controller, new()
        {
            //Ccreate a disconnected controller instance
            T controller = new T();
            // Get context wrapper from HttpContext if available
            HttpContextBase wrapper;
            if (System.Web.HttpContext.Current != null)
            {
                wrapper = new HttpContextWrapper(System.Web.HttpContext.Current);
            }
            else
            {
                throw new InvalidOperationException("Cannot create Controller Context if no active HttpContext instance is available.");
            }
    
            if (routeData == null)
            {
                routeData = new RouteData();
            }
    
            // Add the controller routing if not existing
            if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
            {
                routeData.Values.Add("controller", controller.GetType().Name.ToLower().Replace("controller", ""));
            }
    
            controller.ControllerContext = new ControllerContext(wrapper, routeData, controller);
            return controller;
        }
    
        public static string ViewToString(ControllerContext context, string viewPath, object model = null, bool partial = false)
        {
            // First find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
            {
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
            }
            else
            {
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);
            }
    
            if (viewEngineResult == null)
            {
                throw new FileNotFoundException("View cannot be found.");
            }
    
            // Get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;
    
            string result = null;
    
            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }
    
            return result.Trim();
        }
    
        public static HtmlString RenderWidget(this HtmlHelper htmlHelper)
        {
            var html = ViewToString(CreateController<Core.Controllers.WidgetController>().ControllerContext, "~/Views/Widget/Index.cshtml", null, true);
            return new HtmlString(html);
        }
    }
