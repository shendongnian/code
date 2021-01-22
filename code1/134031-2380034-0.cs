    // Step 1
    var visibleZQuery = from x in xs.AsExpandable()
                             from y in ys
                             from z in yas
                             where
                                 ...
                             select Z;
    // Step 2
    if (filterByA)
    {
        visibleZQuery = visibleZQuery.Where(client => client.a > 10);
    }
    if (filterByB)
    {
        visibleZQuery = visibleZQuery.Where(client => client.b.StartsWith("ABC"));
    }
    Expression<Func<Z, string>> aSelector = z => string.Empty;
    Expression<Func<Z, string>> bSelector = z => string.Empty;
    if (filterByA)
    {
        aSelector = z => z.Client.a;
    }
    if (filterByB)
    {
        bSelector = z => z.Client.e.f.g.b;
    }
    var filteredClientQuery = from z in visibleZQuery
                              select new 
                              { 
                                  id = z.Client.Id, 
                                  a = aSelector.Invoke(z), 
                                  b = aSelector.Invoke(z)
                              }; 
    // Step 3
    filteredClientQuery = filteredClientQuery.Distinct();
    if (filterByA)
    {
        filteredClientQuery = filteredClientQuery.OrderBy(client => client.a);
    }
    else if (filterByB)
    {
        filteredClientQuery = filteredClientQuery.OrderBy(client => client.b);
    }
    filteredClientQuery = filteredClientQuery.Skip(50).Take(30);
    // Step 4
    var fullQuery = from filterClientSummary in filteredClientQuery
                     join client in Clients on filterClientSummary.Id equals client.Id
                     ...;
