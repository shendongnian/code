    public class MyControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(
            RequestContext requestContext, string controllerName)
        {
            return [construct your controller here] ;
        }
    }
