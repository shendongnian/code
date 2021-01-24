    public void TryAddService(Type type, object service)
    {
        if (service == null)
        {
            throw new RegisterServiceException($"Can not register null for type '{type.FullName}'");
        }
        if (this.services.ContainsKey(type))
        {
            throw new RegisterServiceException($"Service for type '{type.FullName}' already registerd.");
        }
        if (!type.IsAssignableFrom(service.GetType()))
        {
            throw new RegisterServiceException($"Type '{type.FullName}' should be assignable from service of type '{service.GetType().FullName}'");
        }
        this.services.Add(type, service);
    }
