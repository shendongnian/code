    using Microsoft.Azure.Management.ResourceManager.Fluent;
    ...
    var rm = ResourceManager.                    
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();
    var resources= rm.GenericResources.List();
    foreach(IGenericResource res in resources)
    {
        ....
    }
