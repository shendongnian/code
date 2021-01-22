    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes",
        Justification = "This attribute is AllowMultiple = true and users might want to override behavior.")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class GenericExceptionHandlerFilter : ActionFilterAttribute, IExceptionFilter
    {
       
        public Type ExceptionType { get; set;}
        public string RedirectToAction { get; set;}
        public string RedirectToController { get; set;}
        protected bool ApplyFilter(ExceptionContext filterContext)
        {
            Type lExceptionType = filterContext.Exception.GetType();
            return (ExceptionType == null ||
                    lExceptionType.Equals(ExceptionType));
        }
        #region IExceptionFilter Members
        public void OnException(ExceptionContext filterContext)
        {
            if (ApplyFilter(filterContext))
            {
                IbfControllerLogger.Log(filterContext.Exception);
                filterContext.ExceptionHandled = true;
                                
                #region Calculate Action Controller Error
                RouteValueDictionary lRoutes = new RouteValueDictionary(new
                    {
                        action = RedirectToAction,
                        controller = String.IsNullOrEmpty(RedirectToController) ? (string)filterContext.RouteData.Values["controller"] : RedirectToController
                    });
                UrlReWriterUtils.UrlReWriter(filterContext.Controller.ViewData, lRoutes);
                #endregion
                filterContext.Controller.TempData[TempDataName.C_TEMPDATA_EXCEPTIONERROR] = filterContext.Exception;
                filterContext.Result = new RedirectToRouteResult(lRoutes);
            }
        }
        #endregion
