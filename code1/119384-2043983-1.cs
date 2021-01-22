    public class SpringControllerFactory : DefaultControllerFactory
    {
        public IController CreateController(RequestContext context, Type controllerType)
        {
            IResource input = new FileSystemResource(context.HttpContext.Request.MapPath("Resource\\objects.xml"));
            IObjectFactory factory = new XmlObjectFactory(input);
            return (IController) factory.GetObject(controllerType.Name);
        }
        public IController CreateController(RequestContext context, string controllerName)
        {
            IController controller = null;
            string controllerClassName = string.Format("{0}Controller", controllerName);
            if (SpringApplicationContext.Contains(controllerClassName))
            {
                controller = SpringApplicationContext.Resolve<IController>(controllerClassName);
                this.RequestContext = context;
            }
            else
            {
                controller = base.CreateController(context, controllerName);
            }
            return controller; 
        }
        public override void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        } 
    }
