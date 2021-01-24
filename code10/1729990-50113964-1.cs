     public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
               ///
    
                //dependencies
                NinjectModule serviceModule = new ServiceModule("connection");
                NinjectModule studentModule = new StudentModule();
                var kernel = new StandardKernel(studentModule, serviceModule);
                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            }
        }
