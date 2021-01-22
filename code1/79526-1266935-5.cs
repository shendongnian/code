    Expression<Func<Client, bool>> clientWhere = c => true;
    if (filterByClientFName)
    {
        clientWhere = clientWhere.AndAlso(c => c.ClientFName == searchForClientFName);
    }
    if (filterByClientLName)
    {
        clientWhere = clientWhere.AndAlso(c => c.ClientLName == searchForClientLName);
    }
