    public class MyControllerFactory : DefaultControllerFactory {
        public override IController CreateController(RequestContext requestContext, string controllerName) {
            // poke around the requestContext object here
            return base.CreateController(requestContext, controllerName);
        }
    }
