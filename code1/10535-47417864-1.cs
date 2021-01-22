        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "HomeRoute",
                "Home",
                "~/Default.aspx"
            );
            routes.MapPageRoute(
                "SecondRoute",
                "Second",
                "~/Second.aspx"
            );
            routes.MapPageRoute(
                "ThirdRoute",
                "Third/{Name}",
                "~/Third.aspx"
            );
        }
