    var yourProxiedInterfaceInstance = ...
    
    // Get the Interceptor that NHibernate uses
    
    var proxy = (IProxy)yourProxiedInterfaceInstance;
    
    var interceptor = proxy.Interceptor;
    
    // You'll need to create a decorator class around the IInterceptor interface
    var yourInterceptor = new SomeCustomInterceptor(interceptor); 
    
    // Replace the interceptor here
    proxy.Interceptor = yourInterceptor;
