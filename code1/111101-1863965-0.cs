    //using Predicate Builder
            public List<Location> FindAllMatching(string[] filters)
            {
               var db = Session.Linq<Location>();
               var expr = PredicateBuilder.False<Location>(); //-OR-
               foreach (var filter in filters)
               {
                   string temp = filter;
                   expr = expr.Or(p => p.Name.Contains(temp));
               }
    
               return db.Where(expr).ToList();
             }
