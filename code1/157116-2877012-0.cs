    var result =  
    from a in db.TableA 
    join b in db.TableB on a.aId equals b.aId 
    group new {A = a, B = b} by b.bValue;
    
      // demonstration of navigating the result
    foreach(var g in result)
    {
      Console.WriteLine(g.Key);
      foreach(var x in g)
      {
        Console.WriteLine(x.A.aId);
        Console.WriteLine(x.B.bId);
      }
    }
