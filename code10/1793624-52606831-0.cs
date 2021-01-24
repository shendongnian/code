    public static class Bootstrapper
        {
           public static void Run()
            {
                SetAutofacContainer();
            }
 
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
         
            // Repositories
            builder.RegisterType<YOUR_REPOSITORY>().As<YOUR_IREPOSITORY>().InstancePerRequest();
 
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
     }
