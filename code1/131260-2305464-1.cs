    var predicate = PredicateBuilder.True<Order>();
    if (search.OrderId))
    {
       predicate = predicate.And(a => SqlMethods.Like(a.OrderID, search.OderID);  
    }
    // ...
    var results = q.Where(predicate);
