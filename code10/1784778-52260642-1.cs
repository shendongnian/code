    // You'll need to include the following namespaces
    using System.Web.Mvc;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    public class WebApiApplication : System.Web.HttpApplication
        // This is the Application_Start event from the Global.asax file.
        protected void Application_Start(object sender, EventArgs e) {
        
        // Create the container as usual.
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        // Register your types, for instance:
        container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
    
        // This is an extension method from the integration package.
        container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
    
        container.Verify();
    
        DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
    }
