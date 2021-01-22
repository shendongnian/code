    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true), AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter {
    private HandleErrorAttribute attribute = new HandleErrorAttribute();
    public ExceptionHandlerAttribute() {
      this.ExceptionType = typeof(Exception);
      this.Order = 1;
    }
    public string View {
      get {
        return attribute.View;
      }
      set {
        attribute.View = value;
      }
    }
    public Type ExceptionType {
      get {
        return attribute.ExceptionType;
      }
      set {
        attribute.ExceptionType = value;
      }
    }
    public void OnException(ExceptionContext filterContext) {
      if (this.ExceptionType.IsInstanceOfType(filterContext.Exception)) {
        string controller = (string)filterContext.RouteData.Values["controller"];
        string action = (string)filterContext.RouteData.Values["action"];
        if (controller == null)
          controller = String.Empty;
        if (action == null)
          action = String.Empty;
        HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controller, action);
        ViewResult result = new ViewResult();
        result.ViewName = this.View;
        result.MasterName = String.Empty;
        result.ViewData = new ViewDataDictionary<HandleErrorInfo>(model);
        result.TempData = filterContext.Controller.TempData;
        filterContext.Result = result;
        filterContext.ExceptionHandled = true;
        filterContext.HttpContext.Response.Clear();
        filterContext.HttpContext.Response.StatusCode = 500;
      }
    }
  }
