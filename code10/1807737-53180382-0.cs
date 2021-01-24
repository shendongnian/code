    public class AppViewEngine : RazorViewEngine
    {
        private const string ApiModeParam = "API__MODE";
        public AppViewEngine()
        {
            //Performance optimization, if we do not need to lookup for vbhtml
            FileExtensions = new[] {"cshtml"};
        }
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            var apiMode = controllerContext.HttpContext.Request.Params[ApiModeParam];
            if (apiMode == null)
            {
                return base.FindPartialView(controllerContext, partialViewName, useCache);
            }
            return GetApiResult(apiMode);
        }
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var apiMode = controllerContext.HttpContext.Request.Params[ApiModeParam];
            if (apiMode == null)
            {
                return base.FindView(controllerContext, viewName, masterName, useCache);
            }
            return GetApiResult(apiMode);
        }
        private ViewEngineResult GetApiResult(string apiMode)
        {
            switch (apiMode)
            {
                case "json":
                    return new ViewEngineResult(new ApiJsonView(), this);
                case "xml":
                    return new ViewEngineResult(new ApiXmlView(), this);
                default:
                    return new ViewEngineResult(new[] { "API__MODE is not supported" });
            }
        }
    }
