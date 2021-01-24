    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            this.RegisterDependencies();   // these are my dependencies
        }
        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Register(ctx =>
            {
                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"];
                if (string.IsNullOrWhiteSpace(connectionString.ConnectionString))
                    throw new InvalidOperationException("No ConnectionString");
                return new System.Data.SqlClient.SqlConnection(connectionString.ConnectionString);
            }).As<System.Data.IDbConnection>().InstancePerLifetimeScope();
            builder.RegisterType<DapperRepository>().As<IOrmRepository>().InstancePerLifetimeScope();
            
            //  Other dependencies is here
            
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
