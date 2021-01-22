        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext != null)
            {
                object[] attributes = filterContext.ActionDescriptor.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                    if (attribute is UnAuthorized)
                        return;
            }
            base.OnAuthorization(filterContext);
        }
