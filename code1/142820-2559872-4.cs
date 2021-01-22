        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext != null)
            {
                object[] attributes = filterContext.ActionDescriptor.GetCustomAttributes(false);
                if (attributes != null)
                {
                    foreach (var attribute in attributes)
                        if (attribute is UnAuthorizedAttribute)
                            return;
                }
            }
            base.OnAuthorization(filterContext);
        }
