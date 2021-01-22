    public class MyViewFactory : WebFormViewEngine
    {
        public override ViewEngineResult FindView(
            ControllerContext controllerContext, 
            string viewName,
            string masterName,
            bool useCache
            )
        {
            controllerContext.Controller.ViewData["viewname"] = viewName;
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
