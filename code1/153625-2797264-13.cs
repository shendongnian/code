    namespace WebApplicationProject
    {
        public class MvcApplication : System.Web.HttpApplication
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                // your routes
            }
    
            protected void Application_Start()
            {
                RegisterRoutes(RouteTable.Routes);
                ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());
            }
        }
    
        public class UnityControllerFactory : DefaultControllerFactory
        {
            private IUnityContainer _container;
    
            public UnityControllerFactory()
            {
                _container = new UnityContainer();
    
                var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                      where typeof(IController).IsAssignableFrom(t)
                                      select t;
    
                foreach (Type t in controllerTypes)
                    _container.RegisterType(t, t.FullName);
    
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
    
                section.Configure(_container);
            }
    
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                // see http://stackoverflow.com/questions/1357485/asp-net-mvc2-preview-1-are-there-any-breaking-changes/1601706#1601706
                if (controllerType == null) { return null; }
    
                return (IController)_container.Resolve(controllerType);
            }
        }
        
    }
