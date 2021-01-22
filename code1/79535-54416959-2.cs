    var predicate = PredicateBuilder.True<Client>();
     
    if (filterByClientFName)
    {
        predicate = predicate.And(c => c.ClientFName == searchForClientFName);
    }
    
    if (filterByClientLName)
    {
            predicate = predicate.And(c => c.ClientLName == searchForClientLName);
    }
    
    var result = context.Clients.Where(predicate).ToArray();
