    ServiceHost newService = new ServiceHost(typeof(YourType));
    foreach (var endpoint in newService.Description.Endpoints)
    {
      endpoint.Contract.ContractBehaviors.Add(new LoggingBehavior());
    }
