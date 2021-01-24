    // From the found interfaces, find the first generic-type definition that has the same type as IRegisterPerRequest<>
    Type contract = obj.GetInterfaces().FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IRegisterPerRequest<>));
    
    // if we find an implemented contract that match our rule, we register it
    if(contract != null)
    {
       // At this point we know that we found one interface that matches your rule.
       // All you have to do is register it.
       // Keep in mind that the generic type your looking for is `contract.GetGenericArguments()[0]` not `obj.GetGenericArguments()[0]` as the obj type is the class which implements the contract.
        container.RegisterType(contract.GetGenericArguments()[0], obj, obj.FullName, new PerRequestLifetimeManager());
    }
