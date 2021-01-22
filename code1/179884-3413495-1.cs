    public class ContextControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = base.GetControllerInstance(requestContext, controllerType);
            Controller contextController = controller as Controller;
            if (contextController != null)
            {
                var context = new ControllerContext(requestContext, contextController);
                contextController.ActionInvoker = new ContextActionInvoker(context);
            }
            return controller;
        }
    }
