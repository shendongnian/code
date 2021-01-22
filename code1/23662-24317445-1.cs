    public class Global : HttpApplication
    {
        public override void Init()
        {
            AreaRegistration.RegisterAllAreas(); //will error out on app_start
            base.Init();
        }
        /// <summary>
        /// Application_Start method.
        /// </summary>
        /// <param name="sender">The caller</param>
        /// <param name="e">The event arguments</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "KMM: This method is called dynamically by the framework.")]
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = StructureMapRegistry.Initialize();
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
