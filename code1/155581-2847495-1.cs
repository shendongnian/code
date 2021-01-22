        protected const string ApplicationAssembliesFolder = "~/Assemblies";
        protected void Application_Start(object sender, EventArgs e)
        {
            var assembliesPath = Server.MapPath(ApplicationAssembliesFolder);
            AppDomain.CurrentDomain.SetShadowCopyPath(
                AppDomain.CurrentDomain.SetupInformation.ShadowCopyDirectories + 
                Path.PathSeparator + assembliesPath);
            Assembly.LoadFrom(
                Path.Combine(assembliesPath, "Example.dll"));
        }
