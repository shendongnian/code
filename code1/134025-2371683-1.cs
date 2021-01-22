    // Step 1 
    IQueryable<Client> visibleClientQuery =
        from x in xs 
        from y in ys 
        from z in yas 
        where 
        ... 
        select z.Client;
    // Step 2 
    if (filterByA) 
    { 
        visibleClientQuery = visibleClientQuery.Where(c => c.a > 10); 
    } 
    else 
    { 
        visibleClientQuery = visibleClientQuery.Where(c => c.e.f.g.b.StartsWith("ABC")); 
    }
    // Step 3 
    visibleClientQuery = visibleClientQuery.Distinct(); 
    if (filterByA) 
    { 
        visibleClientQuery = visibleClientQuery.OrderBy(c => c.a); 
    } 
    else 
    { 
        visibleClientQuery = visibleClientQuery.OrderBy(client => c.e.f.g.b); 
    } 
    visibleClientQuery = visibleClientQuery.Skip(50).Take(30); 
