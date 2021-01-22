    public class ErrorLoggingAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private String _controllerName, _actionName;
        private Boolean _redirectToGenericView = false;
        public ErrorLoggingAttribute()
        {
        }
        public ErrorLoggingAttribute(String actionName, String controllerName)
        {
            _controllerName = controllerName;
            _actionName = actionName;
            _redirectToGenericView = true;
        }
        void IExceptionFilter.OnException(ExceptionContext ec)
        {
            // log error
            if (_redirectToGenericView)
            {
                ec.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", _controllerName},
                    {"action", _actionName}
                });
            }
            else
            {
                ec.Result = new ViewResult
                {
                    ViewName = ((RouteData) ec.RouteData).Values["action"].ToString(),
                    TempData = ec.Controller.TempData,
                    ViewData = ec.Controller.ViewData
                };
            }
            ec.ExceptionHandled = true;
        }
    }
