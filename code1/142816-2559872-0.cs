        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext != null)
            {
                string actionName = filterContext.ActionDescriptor.ActionName;
                Type t = filterContext.Controller.GetType();
                var methodInfo = t.GetMethod(actionName);
                object[] attributes = methodInfo.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is UnAuthorized)
                    {
                        return;
                    }
                }
            }
            base.OnAuthorization(filterContext);
        }
