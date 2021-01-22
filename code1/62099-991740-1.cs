    var bf = new BurrowFramework();
    IFrameworkEnvironment fe = bf.BurrowEnvironment;
    Assembly assembly = Assembly.LoadFrom(Server.MapPath("~/bin/MyProject.Data.dll"));
    Configuration cfg = fe.GetNHConfig("PersistenceUnit1");
    Fluently.Configure(cfg)
	    .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
	    .BuildConfiguration();
    fe.RebuildSessionFactories();
