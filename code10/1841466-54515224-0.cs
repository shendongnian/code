     public class ContactInfoAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext == null || filterContext.HttpContext == null || filterContext.HttpContext.Request == null ||
                    (filterContext.ActionDescriptor.ActionName == "ProfileView" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Account"))
                    return;
                
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                var customer = workContext.CurrentUser;
                if (customer != null)
                {
                    if (customer.PhoneNumber == null || customer.Email == null)
                    {
                        RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                        redirectTargetDictionary.Add("action", "ProfileView");
                        redirectTargetDictionary.Add("controller", "Account");
                        filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
                    }
                }
                base.OnActionExecuting(filterContext);
            }
        }
