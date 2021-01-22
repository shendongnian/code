        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext != null)
            {
                string actionName = filterContext.ActionDescriptor.ActionName;
                Type t = filterContext.Controller.GetType();
                var memberInfos = t.GetMember(actionName);
                foreach (var memberInfo in memberInfos)
                {
                    object[] attributes = memberInfo.GetCustomAttributes(false);
                    foreach (var attribute in attributes)
                    {
                        if (attribute is UnAuthorizedAttribute)
                        {
                            return;
                        }
                    }
                }
            }
            base.OnAuthorization(filterContext);
        }
