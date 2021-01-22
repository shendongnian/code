        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string agentID = filterContext.RouteData.Values["agentID"].ToString();
            OtherMethodCall(agentID);
        }
