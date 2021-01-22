        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
                var exception = filterContext.Exception ?? filterContext.HttpContext.Error;
                if (exception != null)
                {
                   //logger.Error(xxx);
                }
                if (filterContext.Result != null && 
                    filterContext.HttpContext.Error != null)
                {
                   filterContext.HttpContext.ClearError();
                }
                base.OnActionExecuted(filterContext);
        }
