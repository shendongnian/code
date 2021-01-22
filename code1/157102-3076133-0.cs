    //the current class is creating a domain.  No types exist in the domain
    var domain = AppDomain.CreateDomain("2nd Domain");
    
    // create an instance of SomeType in 2nd Doman and create a proxy here
    var assembly = typeof(SomeType).Assembly.FullName;
    var type = typeof(SomeType).Name;
    var proxy = domain.CreateInstanceAndUnwrap(assembly,type);
    // at this point, only one instance exists in 2nd Domain.
    //These will cause the current class to be pulled across the domain boundary
    proxy.Whoops(this);
    proxy.SomeEvent += new EventHandler(AMethodDefinedHere);
    proxy.Callback = AnotherMethodDefinedHere;
