        protected bool HasActionPermission(string actionName, string controllerName)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
                return false;
            var controller = GetControllerByName(ControllerContext.RequestContext, controllerName);
            var controllerDescriptor = new ReflectedControllerDescriptor(controller.GetType());
            var actionDescriptor = controllerDescriptor.FindAction(ControllerContext, actionName);
            return ActionIsAuthorized(ControllerContext, actionDescriptor);
        }
        private static bool ActionIsAuthorized(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            if (actionDescriptor == null)
                return false; // action does not exist so say yes - should we authorise this?!
            AuthorizationContext authContext = new AuthorizationContext(controllerContext, actionDescriptor);
            // run each auth filter until on fails
            // performance could be improved by some caching
            foreach (var filter in FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor))
            {
                var authFilter = filter.Instance as IAuthorizationFilter;
                if (authFilter == null)
                    continue;
                authFilter.OnAuthorization(authContext);
                if (authContext.Result != null)
                    return false;
            }
            return true;
        }
        private static ControllerBase GetControllerByName(RequestContext context, string controllerName)
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
            IController controller = factory.CreateController(context, controllerName);
            if (controller == null)
            {
                throw new InvalidOperationException(
                    String.Format(
                        CultureInfo.CurrentUICulture,
                        "Controller factory {0} controller {1} returned null",
                        factory.GetType(),
                        controllerName));
            }
            return (ControllerBase)controller;
        }
