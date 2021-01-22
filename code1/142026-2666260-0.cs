        /// <summary>
        /// Changes the masterpage to a slim version in AjaxRequest
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var action = filterContext.Result as ViewResult;
            if (action != null && Request.IsAjaxRequest())
            {
                action.MasterName = "Ajax";
            }
            base.OnActionExecuted(filterContext);
        }
