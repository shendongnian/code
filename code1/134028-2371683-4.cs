    public class SubClient
    {
       public int id {get;set;}
       public int? a {get;set;}
       public string b {get;set;}
    }
    // Step 1 
    IQueryable<Client> visibleClientQuery =
        from x in xs 
        from y in ys 
        from z in yas 
        where 
        ... 
        select z.Client;
    IQueryable<SubClient> subClientQuery = null;
    // Step 2 
    if (filterByA) 
    { 
        subClientQuery = visibleClientQuery.Select(c => new SubClient()
        {
            id = c.id,
            a = c.a
        }).Where(x => x.a > 10); 
    } 
    else 
    { 
        subClientQuery = visibleClientQuery.Select(c => new SubClient()
        {
          id = c.id,
          b = c.e.f.g.b
        })
        .Where(x => x.b.StartsWith("ABC")); 
    }
    // Step 3 
    subClientQuery = subClientQuery.Distinct(); 
    if (filterByA) 
    { 
        subClientQuery = subClientQuery.OrderBy(c => c.a); 
    } 
    else 
    { 
        subClientQuery = subClientQuery.OrderBy(c => c.b); 
    } 
    subClientQuery = subClientQuery.Skip(50).Take(30); 
