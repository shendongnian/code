        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // build list of menu items based on user's permissions, and add it to ViewData
            IEnumerable<MenuItem> menu = BuildMenu(); 
            ViewData["Menu"] = menu;
        }
