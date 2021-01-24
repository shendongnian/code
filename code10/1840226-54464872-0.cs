        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller is Controller controller)
            {
                controller.ViewBag.CanEdit = filterContext.HttpContext.User.IsInRole("group1");
