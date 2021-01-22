    public class ControllerFactory : IControllerFactory
        {
            CompositionContainer container;
            DefaultControllerFactory controllerFactory;
    
            public ControllerFactory()
            {
                container = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                controllerFactory = new DefaultControllerFactory();
            }
    
            public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
            {
                var controller = controllerFactory.CreateController(requestContext, ControllerName);
    
                container.ComposeParts(controller);
    
                return controller;
            }
    
            public void ReleaseController(IController controller)
            {
                var disposable = controller as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
