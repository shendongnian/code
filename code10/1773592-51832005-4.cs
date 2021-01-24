    var proxy = domain.CreateInstanceAndUnwrap(proxy.Assembly.FullName, proxy.FullName 
       ?? throw new InvalidOperationException()) as Proxy;
    proxy.Open();  // <------ new method here
    .
    . some time later
    .
    var ids = obj.GetIdentifications();
