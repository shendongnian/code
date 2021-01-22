    var parents = context.Parents.Include("Child").ToList(); //note that ToList is here just to execute the query and get the objects in memory
    
    foreach (var p in parents)
    {
       //do something with parent item
       foreach (var c in p.Child.OrderBy(c => c.Number))
       {
          /do something with the child item
       }
    }
