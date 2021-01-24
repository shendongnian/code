    public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var a = filterContext.HttpContext.Session["abc"];
            /// a should have a value
        }
