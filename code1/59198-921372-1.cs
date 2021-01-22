        private void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            // replace default WebForms view engine.
            ViewEngines.Engines.Remove(ViewEngines.Engines.OfType<WebFormViewEngine>().Single());
            ViewEngines.Engines.Add(new Namespace.MyViewEngine());
        }
