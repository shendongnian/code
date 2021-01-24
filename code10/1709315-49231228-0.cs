    public class Global : HttpApplication
        {
            void Application_Start(object sender, EventArgs e)
            {
                // Code that runs on application startup
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                // Initialize the product database.
                Database.SetInitializer(new ProductDatabaseInitializer());
    
                using (var context = new ProductContext())
                {
                    context.Database.Initialize(force: true);
                }
            }
        }
