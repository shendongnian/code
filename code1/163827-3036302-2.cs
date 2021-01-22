    var merged = list1
      // join the lists by the name 
      .Join(list2, x => x.Name, x => x.Name, (p1, p2) => new { P1 = p1, P2 = p2 } )
      .Select(x => 
        new Project()
        {
          Name = P1.Name,
          Type = P1.Type ?? P2.Type,
          Priority = P1.Priority ?? P2.Priority 
        });
