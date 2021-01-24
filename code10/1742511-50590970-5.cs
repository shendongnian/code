    var domain = AppDomain.CreateDomain("SandboxDomain");
    var loader = (AssemblyLoader)domain.CreateInstanceAndUnwrap(typeof(AssemblyLoader).Assembly.FullName, typeod(AssemblyLoader).FullName);
    // pass the host to the domain (again, this is optional; just for feedbacks)
    loader.Initialize(new DomainHost());
    // Start the work.
    loader.DoWork();
    // At the end, you can unload the domain
    AppDomain.Unload(domain);
