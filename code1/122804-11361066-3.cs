     public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            // Edit the base address of MyService by replacing the "MyService" string below
            RouteTable.Routes.Add(new ServiceRoute("MyService", new WebServiceHostFactory(), typeof(MyService)));
        }
    }
