    public class MvcControllerFactory : DefaultControllerFactory
    {
        private readonly Container _container;
        private readonly IControllerFactory _original;
        public MvcControllerFactory(Container container, IControllerFactory original)
        {
            _container = container;
            _original = original;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, 
                                                                                    Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            if (controllerType == typeof(MyMvcController))
            {
                return (IController)_container.GetInstance(controllerType);
            }
            var controllerName = requestContext.RouteData.GetRequiredString("controller");
            if (!string.IsNullOrEmpty(controllerName))
            {
                return _original.CreateController(requestContext, controllerName);
            }
            return (IController) Activator.CreateInstance(controllerType);
        }
    }
