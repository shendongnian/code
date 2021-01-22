    protected const string ApplicationAssembliesFolder = "~/Assemblies";
    protected void Application_Start(object sender, EventArgs e)
    {
        var assembliesPath = Server.MapPath(ApplicationAssembliesFolder);
        AppDomain.CurrentDomain.SetupInformation.ShadowCopyDirectories +=
            Path.DirectorySeparatorChar + assembliesPath;
        Assembly.LoadFrom(
            Path.Combine(assembliesPath, "Sample.dll"));
    }
