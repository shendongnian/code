    public class NinjectControllerFactory : System.Web.Mvc.DefaultControllerFactory
    {
        private IKernel container;
        public NinjectControllerFactory( IKernel container )
        {
            this.container = container;
        }
        protected override Type GetControllerType( RequestContext requestContext, string controllerName )
        {
            return base.GetControllerType( requestContext, controllerName );
        }
        protected override IController GetControllerInstance( RequestContext requestContext, Type controllerType )
        {
            if ( controllerType != null )
            {
                IController controller = container.Get( controllerType ) as IController;
                Check.Require( controller, "Could not instantiate controller type: {0}", controllerType.FullName );
                return controller;
            }
            return base.GetControllerInstance( requestContext, controllerType );
        }
    }
