    var predicate = PredicateBuilder.True<Client>();
     
    if (filterByClientFName)
    {
        clientWhere = predicate.And(c => c.ClientFName == searchForClientFName);
    }
    
    if (filterByClientLName)
    {
            clientWhere = predicate.And(c => c.ClientLName == searchForClientLName);
    }
    
    var result = context.Clients.Where(predicate).ToArray();
