    public string FooProperty { get; private set; }
    
    public ClassLoader(string domain, string fooProperty)
    {
        FooProperty = fooProperty; // Set it before adding event handler
        Domain = AppDomain.CreateDomain(domain);
        Domain.AssemblyResolve += Domain_AssemblyResolve;
    }
