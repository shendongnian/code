    public bool TryAddService(Type type, object service)
    {
      if (service == null)
      {
        return false;
      }
      if (this.services.ContainsKey(type))
      {
        return false;
      }
      if (!type.IsAssignableFrom(service.GetType()))
      {
        return false;
      }
      try
      {
        this.services.Add(type, service);
      }
      catch
      {
        return false;
      }
      return true;
    }
