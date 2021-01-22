    public object GetInstance(InstanceContext instanceContext, Message message)
    {
        var principal =
            OperationContext.Current.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] 
                as MyPrincipal;
        if (principal != null)
            Thread.CurrentPrincipal = principal;
        return ObjectFactory.GetInstance(_serviceType);
    }
