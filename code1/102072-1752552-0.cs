    public class ErrorLoggingAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private String _controllerName, _actionName;
        private Boolean _validation = true;
        public ErrorLoggingAttribute()
        {
        }
        public ErrorLoggingAttribute(String actionName, String controllerName)
        {
            _controllerName = controllerName;
            _actionName = actionName;
            _validation = false;
        }
        void IExceptionFilter.OnException(ExceptionContext ec)
        {
            if (_validation)
            {
                ec.Result = new ViewResult
                {
                    ViewName = ((RouteData) ec.RouteData).Values["action"].ToString(),
                    TempData = ec.Controller.TempData,
                    ViewData = ec.Controller.ViewData
                };
            }
            else
            {
                ec.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", _controllerName},
                    {"action", _actionName}
                });
            }
            ec.ExceptionHandled = true;
        }
    }
